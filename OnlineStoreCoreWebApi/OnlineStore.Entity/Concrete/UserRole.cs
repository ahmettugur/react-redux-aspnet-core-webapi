using OnlineStore.Core.Attributes;
using OnlineStore.Core.Contracts.Entities;

namespace OnlineStore.Entity.Concrete
{
    public class UserRole : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
