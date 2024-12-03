using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace apiZadanie
{
    public static class Timezone
    {
        private const string apiKey = "NM4UNZ7WQDEG";
        public static async Task<string> WybierzStrefeCzasowa(string strefa)
        {
            string url = $"http://api.timezonedb.com/v2.1/get-time-zone?key={apiKey}&format=json&by=zone&zone={strefa}";

            using (HttpClient klient = new HttpClient())
            {
                HttpResponseMessage odpowiedz = await klient.GetAsync(url);
                odpowiedz.EnsureSuccessStatusCode();
                string odp = await odpowiedz.Content.ReadAsStringAsync();
                var json = JObject.Parse(odp);
                string data = json["formatted"].ToString();

                return data;
            }
        }
        public static async Task<List<string>> PobierzStrefy()
        {
            string url = $"http://api.timezonedb.com/v2.1/list-time-zone?key={apiKey}&format=json";

            using (HttpClient klient = new HttpClient())
            {
                HttpResponseMessage odpowiedz = await klient.GetAsync(url);
                odpowiedz.EnsureSuccessStatusCode();
                string odp = await odpowiedz.Content.ReadAsStringAsync();
                var json = JObject.Parse(odp);
                
                List<string> strefy = new List<string>();

                for (int i = 0; i < json["zones"].Count(); i++)
                {
                    strefy.Add(json["zones"][i]["zoneName"].ToString());
                }
                //string data = json["formatted"].ToString();

                return strefy;
            }
        }
    }
}
