using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chatroom.Model.Util;
using Newtonsoft.Json;

namespace Chatroom.Service.ChatRoom
{
    public class ChatRoomServices : IChatRoomServices
    {

        /// <summary>
        /// return the list of message
        /// </summary>
        /// <returns></returns>
        public async  Task <List<RabbitMQApiResponse>> GetAllMessage()
        {
             List<RabbitMQApiResponse> AResult = new List<RabbitMQApiResponse>();

            using (var aHttpClient = new HttpClient())
            {
                try
                {
                    var aUrl = new Uri($"{Util.Url}");
                    string aCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(Util.UserName + ":" + Util.Password));
                    aHttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    aHttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + aCredentials);

                    var aRabitApi = new RabbitMQApi();
                    string json = JsonConvert.SerializeObject(aRabitApi);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var aResponse = await aHttpClient.PostAsync(Util.Url, data);

                    var aStringContent = await aResponse.Content.ReadAsStringAsync();
                    AResult = JsonConvert.DeserializeObject<List<RabbitMQApiResponse>>(aStringContent);
                }
                catch (Exception eError)
                {
                    throw eError;
                }
            }
            return AResult;
        }
    }
}