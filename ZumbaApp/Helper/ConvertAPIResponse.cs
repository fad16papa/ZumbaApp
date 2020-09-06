using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZumbaApp.Helper
{
    public class ConvertAPIResponse
    {
        public async Task<string> ConvertResponse(HttpResponseMessage responseMessage)
        {
            var message = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<string>(message);
        }
    }
}