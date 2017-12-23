using OnlineStore.Core.Attributes;
using OnlineStore.Core.Contracts.Entities;

namespace OnlineStore.Entity.Concrete
{
    public class User : IEntity
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
