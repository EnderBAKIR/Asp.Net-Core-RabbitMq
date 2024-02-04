# ASP-NET Core - RABBITMQ - SIGNALR
** The applied project I made for the rabbitmq course, which I received a certificate from Udemy.**

------------

- Section 1: Introduction: This section introduces what RabbitMQ is, how it works, and why we should use it. It also covers how to install RabbitMQ and how to create a simple Hello World application.
> DOCKER-RABBITMQ CONTAINER
![Docker-RabbitMQ](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/docker_rabbitmq.PNG "Docker-RabbitMQ")
- ------------

- Section 2: Hello World: This section explains how to create a basic message queue system using RabbitMQ. It covers the concepts of producers, consumers, channels, and queues.

- ------------


- Section 3: Exchange Types: This section explores the different types of exchanges that RabbitMQ supports, such as fanout, direct, topic, and header. It shows how to use them to route messages based on various criteria.
More Details For Exchange Type:https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/tree/main/RabbitMq%20Exchange%20Type
- ------------


- Section 4: Additional Topics: This section covers some additional topics related to RabbitMQ, such as how to send complex types, how to make messages persistent, and how to use worker services and background services.

- ------------


- Section 5: Scenario 1 (Adding watermark to images): This section demonstrates how to use RabbitMQ to perform a long-running task in the background, such as adding watermark to images. It shows how to use a background service to consume messages from a queue and process them asynchronously.
> **ADD PRODUCT IMAGE**
![WaterMark Step 1](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/waterMarkStep1.PNG "WaterMark Step 1")
> **PRODUCT LIST**
![WaterMark Step 2](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/waterMarkStep2.PNG "WaterMark Step 2")
> **wwwroot FOLDER**
![WaterMark Step 3](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/waterMarkStep3.PNG "WaterMark Step 3")
![WaterMark Step 4](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/waterMarkStep4.PNG "WaterMark Step 4")
- ------------


- Section 6: Scenario 2 (Creating excel files from tables): This section shows how to use RabbitMQ to create excel files from database tables. It shows how to use a worker service to produce messages to a queue and how to use SignalR to notify the user when the task is done.
> **EXCEL LOGIN PAGE**
![Excel Login Page](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/ExcelLoginPage.PNG "Excel Login Page")
> **EXCEL CREATİNG AND SIGNALR ALERT**
![Excel Creating](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/excelCreating.png "Excel Creating")
> **EXCEL CREATED AND SIGNALR ALERT**
![Excel Created](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/excelCreated.png "Excel Created")
> **FILE DOWNLOAD**
![File Download](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/excelDownload.png "File Download")
>**FILE CONTENT AND FINISH**
![File Content](https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/blob/main/RabbitMQImages/excelContent.png "File Content")

[1]: http://https://github.com/EnderBAKIR/Asp.Net-Core-RabbitMq/tree/main/RabbitMq%20Exchange%20Type "Excahnge Type Details"
