using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Domain.Model.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public String CreatedUser { get; set; }
        public String UpdatedUser { get; set; }

    }
}
