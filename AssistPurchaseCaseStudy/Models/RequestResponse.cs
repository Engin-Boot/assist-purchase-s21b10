﻿using System.Collections.Generic;


namespace AssistPurchaseCaseStudy.Models
{
    public class RequestResponse
    {
        public Dictionary<string, string[]> ChoiceDictionary { get; set; }
        public string Layer { get; set; }
        public string[] LayerMembers { get; set; }

        public RequestResponse()
        {
            this.ChoiceDictionary = new Dictionary<string, string[]>();
            this.LayerMembers = new[] { "LayerMem1", "LayerMem2" };
            this.Layer = "Layer3";
            this.ChoiceDictionary.Add("Layer1", this.LayerMembers);
            this.ChoiceDictionary.Add("Layer2", this.LayerMembers);
        }
    }
}
