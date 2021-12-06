using BPR2_WebApp.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BPR2_WebApp.Controllers
{
    public class ApiHelper
    {
        private HttpClient client = new HttpClient();

        public ApiHelper()
        {
            client.BaseAddress = new Uri("https://localhost:44357/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<NewsletterDTO>> GetNewsletters()
        {
            List<NewsletterDTO> newsletters = new List<NewsletterDTO>();
            HttpResponseMessage response = await client.GetAsync("Newsletters/");

            if (response.IsSuccessStatusCode)
            {
                newsletters = await response.Content.ReadAsAsync<List<NewsletterDTO>>();
            }
            return newsletters;
        }

        public async Task<NewsletterDTO> GetNewsletter(long id)
        {
            NewsletterDTO newsletter = null;
            HttpResponseMessage response = await client.GetAsync("Newsletters/"+id);

            if (response.IsSuccessStatusCode)
            {
                newsletter = await response.Content.ReadAsAsync<NewsletterDTO>();
            }
            return newsletter;
        }

        public async Task<NewsletterDTO> UpdateNewsletter(long id, NewsletterDTO newsletter)
        {
            var json = JsonConvert.SerializeObject(newsletter);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("Newsletters/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return newsletter;
            }
            return null;
        }

        public async Task<NewsletterDTO> PostNewsletter(NewsletterDTO newsletter)
        {
            var json = JsonConvert.SerializeObject(newsletter);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Newsletters/", content);
            if (response.IsSuccessStatusCode)
            {
                return newsletter;
            }
            return null;
        }

        public async Task<NewsletterDTO> RemoveNewsletter(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync("Newsletters/" + id);
            var newsletter = new NewsletterDTO();

            if (response.IsSuccessStatusCode)
            {
                newsletter = await response.Content.ReadAsAsync<NewsletterDTO>();
            }
            return newsletter;
        }

        public async Task<List<SoldProductDTO>> GetSoldProductsByDate(DateTime date)
        {
            List<SoldProductDTO> soldProductDTOs = new List<SoldProductDTO>();
            HttpResponseMessage response = await client.GetAsync("SoldProducts/"+date.Year+"-"+date.Month+"-"+date.Day);

            if (response.IsSuccessStatusCode)
            {
                soldProductDTOs = await response.Content.ReadAsAsync<List<SoldProductDTO>>();
            }
            return soldProductDTOs;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            HttpResponseMessage response = await client.GetAsync("Products/");

            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<ProductDTO>>();
            }
            return products;
        }

        public async Task<List<ReviewDTO>> GetReviews()
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            HttpResponseMessage response = await client.GetAsync("Reviews/");

            if (response.IsSuccessStatusCode)
            {
                reviews = await response.Content.ReadAsAsync<List<ReviewDTO>>();
            }
            return reviews;
        }

    }
}
