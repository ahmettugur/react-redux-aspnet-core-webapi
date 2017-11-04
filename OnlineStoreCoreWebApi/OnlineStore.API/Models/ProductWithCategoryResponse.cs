using OnlineStore.Entity.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Models
{
    public class ProductWithCategoryResponse
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<ProductWithCategory> Products { get; set; }
    }
}
