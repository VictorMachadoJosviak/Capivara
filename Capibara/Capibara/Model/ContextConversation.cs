using Newtonsoft.Json;
using System.Collections.Generic;

namespace Capibara.Model
{
    public class ContextConversation
    {
        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("system")]
        public System System { get; set; }

    }

    public class System
    {
        [JsonProperty("dialog_stack")]
        public List<DialogStack> DialogStack { get; set; }

        [JsonProperty("dialog_turn_counter")]
        public string DialogTurnCouter { get; set; }

        [JsonProperty("dialog_request_counter")]
        public string DialogRequestCounter { get; set; }
    }

    public class DialogStack
    { 
        [JsonProperty("dialog_node")]
        public string DialogNode { get; set; }

      //  [JsonProperty("_node_output_map")]
       // public NodeOutputMap NodeOutputMap { get; set; }
    }

    public class NodeOutputMap
    {
        public List<string> MyProperty { get; set; }
    }
}