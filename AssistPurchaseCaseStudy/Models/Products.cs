using System.Collections.Generic;

namespace AssistPurchaseCaseStudy.Models
{
    public class Products
    {
        //changed
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Features { get; set; }
        public string[] Services { get; set; }
        public string DisplaySize { get; set; }
        public List<string> OtherInfo { get; set; }

        public Products(string id, string name, string[] features, string[] services, string displaySize)
        {
            this.Id = id;
            this.Name = name;
            this.Features = features;
            this.Services = services;
            this.DisplaySize = displaySize;
            this.OtherInfo = default;
        }

        public Products(string id)
        {
            this.Id = id;
            this.Name = default;
            this.Features = default;
            this.Services = default;
            this.DisplaySize = default;
            this.OtherInfo = default;
        }

        public Products()
        {
            this.Id = default;
            this.Name = default;
            this.Features = default;
            this.Services = default;
            this.DisplaySize = default;
            this.OtherInfo = default;
        }
    }
}
