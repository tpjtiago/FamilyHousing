namespace FamilyHousing.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; set; }
        public decimal TotalIncome { get; set; }
        public int NumberOfDependents { get; set; }
    }
}
