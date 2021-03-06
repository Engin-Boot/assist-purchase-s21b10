﻿using System.ComponentModel.DataAnnotations;

namespace AssistPurchaseFrontend.Models
{
    public class AlertDataModel
    {
        public string CustomerName { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerEmailId { get; set; }
        public string ProductIdConfirmed { get; set; }
        public bool AlertSent { get; set; } = false;
        [Key]
        public int OrderId { get; set; }
    }
}
