using System;

namespace Chatroom.Model.Util
{
    public class MessageDto
    {
        /// <summary>
        /// Represent the User Name
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Represent the Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Represent the Timestamp of the Message
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }

    public  class RabbitMQApi
    {
        /// <summary>
        /// Represent the count of message that we want to retrive
        /// </summary>
        public int count { get; set; } = 50;
        /// <summary>
        /// Represent the queue
        /// </summary>
        public string ackmode { get; set; } = "ack_requeue_true";
        /// <summary>
        /// Represent the encoding type
        /// </summary>
        public string encoding { get; set; } =  "auto";

        public int truncate { get; set; } = 50000;
    }

    public class RabbitMQApiResponse
    {
        /// <summary>
        /// Represent the PayLoad as Response
        /// </summary>
        public string payload { get; set; }
    }

    public static class Util {

        /// <summary>
        /// Represen the URL for our Server on RabbitMQ
        /// </summary>
        public static string RabbitMqURl { get; set; } = "http://localhost:15672/api/queues/%2F/first-queue/get";
        /// <summary>
        /// Represent the Stock URL
        /// </summary>
        public static string StockUrlBase { get; set; } = "https://stooq.com/q/l/?s=";
        public static string StockUrlEnd { get; set; } = "&f=sd2t2ohlcv&h&e=csv";
        /// <summary>
        /// Represent As the default virtual host is called "/", this will need to be encoded as "%2F".
        /// </summary>
        public static string Vhost = "%2";
        /// <summary>
        /// Represent the User name for RabbitMQ  default one.
        /// </summary>
        public static string UserName = "guest";
        /// <summary>
        /// Represent the Password of the RabbitMQ for default User
        /// </summary>
        public static string Password = "guest";
        /// <summary>
        /// Represent the Application Json format that is going to be used
        /// </summary>
        public static string Applicationjson = "application/json";
        /// <summary>
        /// Represent the Connection String of RabbitMQ
        /// </summary>

        public static string RabbitMQConnectionString { get; set; } = "amqp://guest:guest@localhost:5672";
        /// <summary>
        /// Represent  the name of the Queue
        /// </summary>

        public static string MyFirstQueue { get; set; } = "first-queue";

        /// <summary>
        ///  response example code quote is Price per share
        /// </summary>
        public static string BotResponse { get; set; } = " per share ";

        /// <summary>
        /// Represent the BotName
        /// </summary>
        public static string BotName { get; set; } = "Bot";


        public readonly static string AppleIncCommand  = "stock_code = aapl.us";

        public static  string EuroCommand = "stock_code";

    }

    public class StockResponseApi
    {
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public int Volume { get; set; }
    }
}



