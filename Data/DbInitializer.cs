using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{ Name = "Shampoo" },
                new Category{ Name = "Conditioner" },
                new Category{ Name = "Gel" },
                new Category{ Name = "Mask" },

            };

            foreach(Category s in categories)
            {
    
                context.Categories.Add(s);
            }


            context.SaveChanges();
        }
    }
}
