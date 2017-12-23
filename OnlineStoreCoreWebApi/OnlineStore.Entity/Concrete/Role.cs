using OnlineStore.Core.Attributes;
using OnlineStore.Core.Contracts.Entities;

namespace OnlineStore.Entity.Concrete
{
    public class Role : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
