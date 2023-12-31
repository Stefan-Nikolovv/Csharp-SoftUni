﻿

using System.ComponentModel.DataAnnotations;
using Invoices.Common;
using Invoices.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductsClients =  new HashSet<ProductClient>();
        }

        [Key]
        public  int  Id { get; set; }
        [MaxLength(ValidationConstants.ProductNameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
   
        public  decimal Price { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        public virtual ICollection<ProductClient> ProductsClients { get; set; }
    }
}
