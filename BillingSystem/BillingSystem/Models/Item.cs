using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Models
{
    public class Item
    {
        public int index { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
    }
}