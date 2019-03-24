using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace First_Slack_App
{
    class SlackMessageWriter
    {
        private readonly string _url;
        private readonly HttpClient _client;

        public SlackMessageWriter(string token)
        {
            _url = "https://slack.com/api/chat.postMessage";
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task WriteMessage(string message)
        {
            var postObject = new { channel = "#general", text = message };
            var json = JsonConvert.SerializeObject(postObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync(_url, content);
        }

        public async Task WriteSecretMessage(string secretMessage)
        {
            uint hash = 5381;
            uint i = 0;

            for (i=0; i < secretMessage.Length; i++)
            {
                hash = ((hash << 5) + hash) + ((byte)secretMessage[(int)i]);
            }

            await WriteMessage(System.Convert.ToString(hash));
        }
    }
}
