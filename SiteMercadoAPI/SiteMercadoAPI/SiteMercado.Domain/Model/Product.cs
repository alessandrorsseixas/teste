using SiteMercado.Domain.Model.Validation;
using SiteMercado.Domain.SeedWorks.Classes;
using SiteMercado.Domain.SeedWorks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Domain.Model
{
    public class Product: Entity
    {
     
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }

        public bool IsValidObject(Product product)
        {
            
            if (product == null)
            {
                NotificationDomainEvent(string.Concat("O objeto da classe {0} está nullo", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString()));
                return false;
            }
            else
            {
                if (!ExecutarValidacao(new ProductValidation(), product)) return false;

                return true;
            }

            
        }

    }
}
