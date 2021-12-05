using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chatroom.Model.Util;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Chatroom.Service.ChatRoom
{
    public class ChatRoomServices : IChatRoomServices
    {

        /// <summary>
        /// return the list of message from RabittMq
        /// </summary>
        /// <returns></returns>
        public async Task<List<RabbitMQApiResponse>> GetAllMessage()
        {
            List<RabbitMQApiResponse> AResult = new List<RabbitMQApiResponse>();
             
            using (var aHttpClient = new HttpClient())
            {
                try
                {
                    var aUrl = new Uri($"{Util.RabbitMqURl}");
                    string aCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(Util.UserName + ":" + Util.Password));
                    aHttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Util.Applicationjson));
                    aHttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + aCredentials);

                    var aRabitApi = new RabbitMQApi();
                    string aJson = JsonConvert.SerializeObject(aRabitApi);
                    var aData = new StringContent(aJson, Encoding.UTF8, Util.Applicationjson);
                    var aResponse = await aHttpClient.PostAsync(Util.RabbitMqURl, aData);

                    string aStringContent = await aResponse.Content.ReadAsStringAsync();
                    AResult = JsonConvert.DeserializeObject<List<RabbitMQApiResponse>>(aStringContent);
                    
                }
                catch (Exception eError)
                {
                    throw eError;
                }
            }
            return AResult;
        }

        public bool SendMessage(MessageDto theMessage)
        {
            bool aSuccess = true;
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(Util.RabbitMQConnectionString)
            };

            try
            {
                using var aConnection = connectionFactory.CreateConnection();
                using var aChannel = aConnection.CreateModel();
                aChannel.QueueDeclare(Util.MyFirstQueue,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var aMessage = new { User = theMessage.User, Message = theMessage.Message, TimeStamp = DateTime.Now };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(aMessage));
                aChannel.BasicPublish("", Util.MyFirstQueue, null, body);
                 
            }
            catch (Exception aError)
            {
                throw aError;
            }

            return  aSuccess;
           
        }

        #region Private  methods


        /// <summary>
        ///  return the price per share of the stock 
        /// </summary>
        /// <param name="theStockCode"> the code of the stock</param>
        /// <returns>aStockResponse  a list of the StockResponse </returns>
        public async Task<string> GetStockResponse(string theStockCode)
        {

            List<object> aResponseList = new List<object>();
            using (var aHttpClient = new HttpClient())
            {
                try
                {
                    var aUrl = new Uri($"{Util.StockUrl}");
                    aHttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Util.Applicationjson));
                    var aResponse = await aHttpClient.GetAsync(aUrl);
                    var aStringContent = await aResponse.Content.ReadAsStringAsync();
                    var aJson = CsvToJsonConverter(aStringContent);
                    aResponseList = JsonConvert.DeserializeObject<List<object>>(aJson);
                }
                catch (Exception eError)
                {
                    throw eError;
                }
            }


            string aCombindedString = string.Join("-", aResponseList);
            StockResponseApi aStockResponse = JsonConvert.DeserializeObject<StockResponseApi>(aCombindedString);

            var aResponseMessage = $"{theStockCode} quote is ,{aStockResponse.High}{Util.BotResponse}";

            return aResponseMessage;
        }

        /// <summary>
        /// validate if the Bot need to response the message
        /// </summary>
        /// <param name="theMeesage"></param>
        /// <returns></returns>

        public async Task<string> GetBotResponse(MessageDto theMessage)
        {
            string aStockResponse = string.Empty;
            //  validate message
            // theMessage.Message

            
            Char value = 'E';
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            Boolean result = theMessage.Message.Contains(value, comp);


            var code = "appl.us";
                 aStockResponse = await GetStockResponse(code);
                var aBotMessage = new MessageDto()
                {
                    User = Util.BotName,
                    Message = aStockResponse,
                    TimeStamp = DateTime.Now
                };
                 SendMessage(aBotMessage);
            
                // this code need to dynamic plzzzz
             
                return aStockResponse;
          
        }



        





        /// <summary>
        /// Helper to convert the Cvs file that comes from the Api call as response to a Json
        /// </summary>
        /// <param name="theFile"></param>
        /// <returns>aJson is the response of the stock</returns>

        private string CsvToJsonConverter(string theFile)
        {
            string aJson = string.Empty;
            
            string[] aLines = theFile.Split(new string[] { "\n" }, System.StringSplitOptions.None);

            if (aLines.Length > 1)
            {
                // parse headers
                string[] headers = aLines[0].Split(',');

                StringBuilder sbjson = new StringBuilder();
                sbjson.Clear();
                sbjson.Append("[");

                // parse data
                for (int i = 1; i < aLines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(aLines[i])) continue;
                    if (string.IsNullOrEmpty(aLines[i])) continue;

                    sbjson.Append("{");

                    string[] data = aLines[i].Split(',');

                    for (int h = 0; h < headers.Length; h++)
                    {
                        sbjson.Append(
                            $"\"{headers[h]}\": \"{data[h]}\"" + (h < headers.Length - 1 ? "," : null)
                        );
                    }

                    sbjson.Append("}" + (i < aLines.Length - 1 ? "," : null));
                }

                sbjson.Append("]");

                aJson = sbjson.ToString();

            }
            return aJson;
        }

       
    }
    #endregion
}
