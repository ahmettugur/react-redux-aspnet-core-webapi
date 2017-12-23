using OnlineStore.Core.Repository.EntityFramework;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Entity.ComplexType;

namespace OnlineStore.Data.EntityFramework.Concrete
{
    public class EFUserRepository : EFGenericRepository<User, OnlineStoreContext>, IUserRespository
    {
        public string[] GetUserRoles(User user)
        {
            using (var context = new OnlineStoreContext())
            {
                var roles = (from r in context.Roles
                             join ur in context.UserRoles
                             on r.Id equals ur.RoleId
                             where ur.UserId == user.UserId
                             select r.Name).ToArray();

                return roles;

            }
        }
    }
}
