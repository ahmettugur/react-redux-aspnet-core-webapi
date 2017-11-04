using OnlineStore.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Entity.Concrete;
using System.Linq.Expressions;
using OnlineStore.Data.Contracts;

namespace OnlineStore.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRespository _userRespository;

        public UserService(IUserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        public User Add(User entity)
        {
            return _userRespository.Add(entity);
        }

        public int Delete(User entity)
        {
            return _userRespository.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> predicate)
        {
            return _userRespository.Get(predicate);
        }

        public List<User> GetAll(Expression<Func<User, bool>> predicate = null)
        {
            return _userRespository.GetAll(predicate);
        }

        public string[] GetUserRoles(User user)
        {
            return _userRespository.GetUserRoles(user);
        }

        public User Update(User entity)
        {
            return _userRespository.Update(entity);
        }
    }
}
