using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace DataRange.UI
{
    class Program
    {
        private const string APP_PATH = "http://localhost:44391";
        private static string token;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter UserName:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            var registerResult = Register(userName, password);

            Console.WriteLine("Status code of registration: {0}", registerResult);

            Dictionary<string, string> tokenDictionary = GetTokenDictionary(userName, password);
            token = tokenDictionary["access_token"];

            Console.WriteLine();
            Console.WriteLine("Access Token:");
            Console.WriteLine(token);

            Console.WriteLine();
            string userInfo = GetUserInfo(token);
            Console.WriteLine("User: ");
            Console.WriteLine(userInfo);

            

            Console.WriteLine("Add new dates: (1), or search dates: (2)?");
            string asd = Console.ReadLine();
            switch (asd)
            {
                case "1":
                    Console.WriteLine("Please, enter first date range in format: year/month/day");
                    string firstDate = Console.ReadLine();
                    Console.WriteLine("Please, enter last date range in format: year/month/day");
                    string lastDate = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Please, enter first date range in format: year/month/day");
                    firstDate = Console.ReadLine();
                    Console.WriteLine("Please, enter last date range in format: year/month/day");
                    lastDate = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("wrong choice of operation");
                    break;
            }         
            Console.Read();
        }

        
        static string Register(string userName, string password)
        {
            var user = new UserModel
            {
                UserName = userName,
                Password = password
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/User/Register", user).Result;
                return response.StatusCode.ToString();
            }
        }
        
        static Dictionary<string, string> GetTokenDictionary(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "Password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(APP_PATH + "/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }

        
        static HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }

        
        static string GetUserInfo(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/User/UserInfo").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        static string Authentication(string userName, string password)
        {
            var user = new UserModel
            {
                UserName = userName,
                Password = password
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/User/Authorize", user).Result;
                return response.StatusCode.ToString();
            }
        }
        static string CreateNote(string firstDate, string lastDate)
        {
            var newDate = new DateModel
            {
                FirstDate = Convert.ToDateTime(firstDate),
                LasttDate = Convert.ToDateTime(lastDate)
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/Date/AddDates", newDate).Result;
                return response.StatusCode.ToString();
            }
        }
        static string GetNotes(string firstDate, string lastDate)
        {
            var searchDate = new DateModel
            {
                FirstDate = Convert.ToDateTime(firstDate),
                LasttDate = Convert.ToDateTime(lastDate)
            };
            
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/Date/GetDates", searchDate).Result;
                return response.StatusCode.ToString();
            }
        }

    }
}

