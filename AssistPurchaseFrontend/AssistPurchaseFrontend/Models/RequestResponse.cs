using System.Collections.Generic;

namespace AssistPurchaseFrontend.Models
{
    public class RequestResponse
    {
        public Dictionary<string, string[]> ChoiceDictionary { get; set; }
        public string Layer { get; set; }
        public string[] LayerMembers { get; set; }

        public RequestResponse()
        {
            this.ChoiceDictionary = new Dictionary<string, string[]>();
            this.LayerMembers = new string[] { };
            this.Layer = "startLayer";
        }
    }
}
