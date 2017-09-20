using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Capibara.Helpers.StringsProperties;

namespace Capibara.Model
{
    public class Conversa
    {        
        [JsonProperty(conStrPergunta)]
        public string ConStrPergunta { get; set; }

        [JsonProperty(conDtmRecebimentoPergunta)]
        public long ConDtmRecebimentoPergunta { get; set; }

        [JsonProperty(conStrResposta)]
        public string ConStrResposta { get; set; }

        [JsonProperty(conDtmEnvioResposta)]
        public long ConDtmEnvioResposta { get; set; }

        [JsonProperty(contextConversation)]
        public IDictionary<string,object> ContextConversation { get; set; }
 

    }
}
