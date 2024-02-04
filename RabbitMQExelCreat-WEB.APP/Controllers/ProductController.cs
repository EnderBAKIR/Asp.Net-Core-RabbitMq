using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQExelCreat_WEB.APP.Models;
using RabbitMQExelCreat_WEB.APP.Service;

namespace RabbitMQExelCreat_WEB.APP.Controllers
{   
    [Authorize]
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly RabbitMQPublisher _rabbitMQPublisher;


        public ProductController(UserManager<AppUser> userManager, AppDbContext context ,RabbitMQPublisher rabbitMQPublisher )
        {
            _userManager = userManager;
            _context = context;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> CreateProductExcel()
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);

            var fileName = $"product-excel-{Guid.NewGuid().ToString().Substring(1, 10)}";

            UserFile userFile = new()
            {
                FileName = fileName,
                UserId = user.Id.ToString(),
                FileStatus = FileStatus.Creating
            };
            await _context.UserFiles.AddAsync(userFile);
            await _context.SaveChangesAsync();
            //rabbitmq ya mesaj gönderme
            _rabbitMQPublisher.Publish(new Shared.CreateExcelMessage
            {
                
                FileId = userFile.Id
            });
            

            TempData["StartCreatingExcel"] = true;

          return RedirectToAction(nameof(Files));

        }

        public async Task<IActionResult> Files()
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);

            var value = await _context.UserFiles.Where(x => x.UserId == user.Id.ToString()).OrderByDescending(x=>x.Id).ToListAsync();//this method for get all files for this user
            return View(value);
        }
    }
}
