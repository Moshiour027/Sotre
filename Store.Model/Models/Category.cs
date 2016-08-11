using System;
using System.Collections.Generic;

namespace Store.Model.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateUpdated { get; set; }

        public virtual List<Gadget> Gedgets { get; set; }
    }
}