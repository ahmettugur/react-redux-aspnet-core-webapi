using OnlineStore.Core.Repository.EntityFramework;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.EntityFramework.Concrete
{
    public class CategoryRepository : GenericRepository<Category, OnlineStoreContext>, ICategoryRepository
    {
    }
}
