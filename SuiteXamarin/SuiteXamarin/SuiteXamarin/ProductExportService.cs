using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuiteXamarin
{
    public class ProductExportService
    {
        public async Task<string> GetData()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://geo.groupkt.com/ip/172.217.3.14/json");
                return await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<TransactionalInformation> ExportProduct(ProductExportViewModel model)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://xamarin-rest-service.azurewebsites.net/demo/registeruser", content);

                var resultStr = await result.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<TransactionalInformation>(resultStr);
            }
        }

        //public async Task<string> RegisterUserFormRequest(ProductExportViewModel model)
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    //    var content = new FormUrlEncodedContent(new[]
        //    //    {
        //    //        new KeyValuePair<string, string>("Username", model.Username),
        //    //        new KeyValuePair<string, string>("Password", model.Password)
        //    //    });

        //    //    var result = await client.PostAsync("http://xamarin-rest-service.azurewebsites.net/demo/registeruser", content);
        //    //    return await result.Content.ReadAsStringAsync();
        //    //}
        //    return null;
        //}
    }
}
