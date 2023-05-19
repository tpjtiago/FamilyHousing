using FamilyHousing.Domain.Entities;
using FamilyHousing.Domain.Models;

namespace FamilyHousing.Domain.Contracts.Services
{
    public interface IFamilyService
    {
        Task<Family> Add(FamilyModel familyModel);
        Task<FamilyModel> GetbyId(int id);
        Task<List<FamilyModel>> GetAll();
        Task<List<FamilyModel>> GetListEligibleFamilies();
    }
}
