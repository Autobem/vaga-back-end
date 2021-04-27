using BuildingBlocks.Domain.Generics.CPF;
using BuildingBlocks.Test.Request;
using BuildingBlocks.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuildingBlocks.Test
{
    public abstract class BaseApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public BaseApplicationFactory()
        {
            this.Client = this.CreateClient();

            this.JsonOptions = new JsonSerializerOptions();
            this.JsonOptions.Converters.Add(new CPFConverter());
            this.JsonOptions.PropertyNameCaseInsensitive = true;
        }

        public HttpClient Client { get; set; }
        public JsonSerializerOptions JsonOptions { get; set; }

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
            string json = JsonSerializer.Serialize(Payload, this.JsonOptions);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            return httpContent;
        }

        private async Task<ResponseMessage<TContent>> DeserializeRequestAsync<TContent>(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            RequestResponse<TContent> model = default;

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                model = JsonSerializer.Deserialize<RequestResponse<TContent>>(jsonString, this.JsonOptions);
            }

            return new ResponseMessage<TContent>()
            {
                StatusCode = response.StatusCode,
                Content = model
            };
        }
    }
}
