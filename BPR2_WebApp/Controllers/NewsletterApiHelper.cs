using BPR2_WebApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BPR2_WebApp.Controllers
{
    public class NewsletterApiHelper
    {
        private static HttpClient client = new HttpClient();

        public NewsletterApiHelper()
        {
            client.BaseAddress = new Uri("https://localhost:44357/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<NewsletterDTO>> getNewsletters()
        {
            List<NewsletterDTO> newsletters = new List<NewsletterDTO>();
            HttpResponseMessage response = await client.GetAsync("Newsletters/");

            if (response.IsSuccessStatusCode)
            {
                newsletters = await response.Content.ReadAsAsync<List<NewsletterDTO>>();
            }
            return newsletters;
        }

    }
}
