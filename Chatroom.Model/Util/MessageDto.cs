using System;
namespace Chatroom.Model.Util
{
    public class MessageDto
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public  class RabbitMQApi
    {
        public int count { get; set; } = 50;
        public string ackmode { get; set; } = "ack_requeue_true";
        public string encoding { get; set; } =  "auto";
        public int truncate { get; set; } = 50000;
    }

    public class RabbitMQApiResponse
    {
        public string payload { get; set; }
    }

    public static class Util {

        public static string Url { get; set; } = "http://localhost:15672/api/queues/%2F/first-queue/get";
        public static string Vhost = "%2";
        public static string UserName = "guest";
        public static string Password = "guest";

    }
}



