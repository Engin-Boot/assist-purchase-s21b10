﻿using System.ComponentModel.DataAnnotations;

namespace AssistPurchaseCaseStudy.Models
{
    public class AlertDataModel
    {
        public string CustomerName { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerEmailId { get; set; }
        public string ProductIdConfirmed { get; set; }
        public bool AlertSent { get; set; }
        [Key]
        public int OrderId { get; set; }
    }
}
