using FamilyHousing.Domain.Contracts;

namespace FamilyHousing.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public BaseEntity() => CreateDate = DateTime.Now;

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
