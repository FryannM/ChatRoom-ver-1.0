# Chat Room Netcore
● Allow registered users to log in and talk with other users in a chatroom.
● Allow users to post messages as commands into the chatroom with the following format
/stock=stock_code
● Create a decoupled bot that will call an API using the stock_code as a parameter
(https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here aapl.us is the
stock_code)
● The bot should parse the received CSV file and then it should send a message back into
the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot.
● Have the chat messages ordered by their timestamps and show only the last 50 messages.
● Unit test the functionality you prefer.


## Whats On it?

*   Razor Pages Project
*   API NET CORE 3.1
*   Generate of JWT
*   Segregate by Services Layer ,Data Access Layer, Controller Layer and so on
*   Entity Framework
*   Unit Test with XUnit

### Prerequisites

Visual Studio 2019... with SDK NETCORE 3.0 and so on!

## Versioning

Git
## Migrations: 

* .NET CLI → dotnet-ef migrations add Initial
*  NuGet Package Manager Console → Add-Migration Initial
* Create and update the Database:
* .NET CLI → dotnet-ef database update
*  NuGet Package Manager Console → Update-Database
*  

 ### Docker Pulling some stuff

*  Setting up RabbitMQ on Docker 
## RUN 
* docker pull rabbitmq:3-management
* docker run -d --hostname  my-rabbit --name fryann-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management 



 

