using BuildingBlocks.Test.Request;
using BuildingBlocks.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Test
{
    public abstract class BaseApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public BaseApplicationFactory()
        {
            this.Client = this.CreateClient();
        }

        public HttpClient Client { get; set; }

        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);
        }

        public async Task<ResponseMessage<TContent>> GetAsync<TContent>(string? requestUri)
        {
            var response = await this.Client.GetAsync(requestUri);
            return await this.DeserializeRequestAsync<TContent>(response);
        }

        public async Task<ResponseMessage<TContent>> PostAsync<TContent>(string? requestUri, object Payload)
        {
            var httpContent = this.CreatePayload(Payload);
            var response = await this.Client.PostAsync(requestUri, httpContent);
            return await this.DeserializeRequestAsync<TContent>(response);
        }

        public async Task<ResponseMessage<object>> PutAsync(string? requestUri, object Payload)
        {
            var httpContent = this.CreatePayload(Payload);
            var response = await this.Client.PutAsync(requestUri, httpContent);
            return await this.DeserializeRequestAsync<object>(response);
        } 
        
        public async Task<ResponseMessage<object>> DeleteAsync(string? requestUri)
        {
            var response = await this.Client.DeleteAsync(requestUri);
            return await this.DeserializeRequestAsync<object>(response);
        }

        private StringContent CreatePayload(object Payload)
        {
            string json = JsonConvert.SerializeObject(Payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            return httpContent;
        }

        private async Task<ResponseMessage<TContent>> DeserializeRequestAsync<TContent>(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<RequestResponse<TContent>>(jsonString);

            return new ResponseMessage<TContent>()
            {
                StatusCode = response.StatusCode,
                Content = model
            };
        }
    }
}
