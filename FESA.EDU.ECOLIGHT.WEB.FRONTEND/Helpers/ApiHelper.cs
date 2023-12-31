﻿
using System.Text;
using System.Text.Json;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers
{
    public static class ApiHelper
    {
        public static async Task<HttpResponseMessage> SendGetRequest(HttpClient client, string endpoint)
        {
            return await client.GetAsync(endpoint);
        }

        public static async Task<HttpResponseMessage> SendPostRequest<Request>(HttpClient client, string endpoint, Request request)
        {
            return await client.PostAsJsonAsync(endpoint, request);
        }

        public static async Task<HttpResponseMessage> SendPostRequest(HttpClient client, string endpoint)
        {

            return await client.PostAsync(endpoint, null);
        }

        public static async Task<HttpResponseMessage> SendPutRequest<Resquest>(HttpClient client, string endpoint, Resquest request)
        {
            return await client.PutAsJsonAsync(endpoint, request);
        }

        public static async Task<HttpResponseMessage> SendDeleteRequest<Resquest>(HttpClient client, string endpoint, Resquest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await client.DeleteAsync(endpoint);
        }
    }
}
