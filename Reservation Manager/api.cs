using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Reservation_Manager;
using Newtonsoft.Json;


namespace Reservation_Manager
{
    internal class api
    {

        public static async Task Main(string[] args)
        {
            dynamic response = await api.makeRequest("https://7157-108-214-189-156.ngrok-free.app/api/v1/reservations");
        }

        public static async Task<dynamic> makeRequest(string url)
        {
            using var client = new HttpClient();

            var result = await client.GetStringAsync(url);
            dynamic json = JsonConvert.DeserializeObject(result);

            return json;
        }

    }
}
