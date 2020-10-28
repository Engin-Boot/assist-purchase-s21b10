using System.Collections.Generic;

namespace AssistPurchaseFrontend.Models
{
    public class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Features { get; set; }
        public string[] Services { get; set; }
        public string DisplaySize { get; set; }
        public List<string> OtherInfo { get; set; }
    }
}
