using System.Collections.Generic;
using Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Managing_Adults.Data.Impl
{
    public class AdultService : IAdultService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public AdultService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<HttpStatusCode> AddAdult(Adult adult)
        {
            string familySerialized = JsonSerializer.Serialize(adult);

            StringContent content = new StringContent(
                familySerialized,
                Encoding.UTF8,
                MediaTypeNames.Application.Json
            );
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:5003/Adults", content);
            return responseMessage.StatusCode;
        }
        
        public async Task RemoveAdultAsync(int adultId)
        {
            await client.DeleteAsync($"{uri}/Adults/{adultId}");
        }
    }
}