using OnlineStore.Core.Contracts.Repository.EntityFramework;
using OnlineStore.Entity.ComplexType;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Contracts
{
    public interface IUserRespository : IGenericRepository<User>
    {
        string[] GetUserRoles(User user);
    }
}
