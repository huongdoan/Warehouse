//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Net;
//using System.IO;
//using System;

//namespace SuiteXamarin
//{
//    public class DataService
//    {
//        public static async Task<dynamic> getDataFromService(string queryString)
//        {
//            HttpClient client = new HttpClient();
//            var response = await client.GetAsync(queryString);

//            dynamic data = null;
//            if (response != null)
//            {
//                string json = response.Content.ReadAsStringAsync().Result;
//                data = JsonConvert.DeserializeObject(json);
//            }

//            return data;
//        }
//        // Gets weather data from the passed URL.
//        private async Task<JsonValue> FetchWeatherAsync(string url)
//        {
//            // Create an HTTP web request using the URL:
//            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
//            request.ContentType = "application/json";
//            request.Method = "GET";

//            // Send the request to the server and wait for the response:
//            using (WebResponse response = await request.get())
//            {
//                // Get a stream representation of the HTTP web response:
//                using (Stream stream = response.GetResponseStream())
//                {
//                    // Use this stream to build a JSON document object:
//                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
//                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

//                    // Return the JSON document:
//                    return jsonDoc;
//                }
//            }
//        }
//    }
//}
