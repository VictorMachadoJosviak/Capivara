using Capibara.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Service
{
    public class CapivaraService : ICapivaraService
    {
        public Conversa Context { get; set; }

        private const string URL_POST = "https://capibara.mybluemix.net/capws/conversaController/resposta";

        public async Task<Conversa> SendTextToService(string conversa)
        {
            try
            {
                //var conv = new
                //{
                //    conStrPergunta = conversa,
                //    conStrResposta = "",
                //    contextConversation = default(object)
                //};
                var conv = new Conversa
                {
                    ConStrPergunta = conversa
                };
            
                
                var json = Context != null ? JsonConvert.SerializeObject(Context) :JsonConvert.SerializeObject(conv);

                var client = new HttpClient();

                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(URL_POST, content);
                
                string resultContent = await response.Content.ReadAsStringAsync();

                Conversa c = JsonConvert.DeserializeObject<Conversa>(resultContent);

                return c;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
