using Capibara.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Capibara.Helpers.CapivaraHelper;
using static Capibara.Helpers.StringsProperties;

namespace Capibara.Service
{
    public class CapivaraService : ICapivaraService
    {
        public Conversa Context { get; set; }

        private const string URL_POST = "https://capibara.mybluemix.net/capws/conversaController/resposta";

        public async Task<Conversa> SendTextToService(string pegunta)
        {
            try
            {
               
                var conversa = new Conversa
                {
                    ConStrPergunta = pegunta
                };

                if (Context != null)
                {
                    Context.ConStrPergunta = pegunta;
                }
                
                var json = Context != null ? JsonConvert.SerializeObject(Context) :
                                             JsonConvert.SerializeObject(conversa);

                var client = new HttpClient();

                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(URL_POST, content);
                
                string resultContent = await response.Content.ReadAsStringAsync();
                var dic = DeserializeToDictionary(resultContent);

                conversa.ConDtmEnvioResposta = (long) dic[conDtmEnvioResposta];
                conversa.ConStrResposta = dic[conStrResposta].ToString();
                conversa.ConDtmRecebimentoPergunta = (long) dic[conDtmRecebimentoPergunta];
                conversa.ConStrPergunta = dic[conStrPergunta].ToString();
                conversa.ContextConversation = (IDictionary<string, object>)dic[contextConversation];
                

                return conversa;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
