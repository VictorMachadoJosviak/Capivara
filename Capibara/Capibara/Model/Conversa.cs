using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capibara.Model
{
    public class Conversa
    {
        public Conversa()
        {
            ContextConversation = new ContextConversation();
        }
        [JsonProperty("conStrPergunta")]
        public string ConStrPergunta { get; set; }

        [JsonProperty("conDtmRecebimentoPergunta")]
        public long ConDtmRecebimentoPergunta { get; set; }

        [JsonProperty("conStrResposta")]
        public string ConStrResposta { get; set; }

        [JsonProperty("conDtmEnvioResposta")]
        public long ConDtmEnvioResposta { get; set; }

        [JsonProperty("contextConversation")]
        public ContextConversation ContextConversation { get; set; }

    }
}
