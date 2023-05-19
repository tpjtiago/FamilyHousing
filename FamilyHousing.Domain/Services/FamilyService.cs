using AutoMapper;
using FamilyHousing.Domain.Contracts.Repositories;
using FamilyHousing.Domain.Contracts.Services;
using FamilyHousing.Domain.Entities;
using FamilyHousing.Domain.Models;

namespace FamilyHousing.Domain.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Family> _repository;

        public FamilyService(IMapper mapper, IRepository<Family> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Family> Add(FamilyModel familyModel)
        {
            var result = await _repository.Add(_mapper.Map<Family>(familyModel));

            return result;

        }

        public async Task<FamilyModel> GetbyId(int id)
        {
            var result = await _repository.Get(id);

            return _mapper.Map<FamilyModel>(result);
        }

        public async Task<List<FamilyModel>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<FamilyModel>>(result);
        }

        public async Task<List<FamilyModel>> GetListEligibleFamilies()
        {
            var familiesList = await _repository.GetAll();
            var families = _mapper.Map<List<FamilyModel>>(familiesList);

            families.ForEach(family =>
            {
                family.Score = CalculateScore(family.TotalIncome, family.NumberOfDependents);
            });

            return families.OrderByDescending(p => p.Score)
                          .ThenBy(p => p.TotalIncome)
                          .ToList();
        }

        private static int CalculateScore(decimal totalIncome, int numberOfDependents)
        {
            int incomeScore = CalculateIncomeScore(totalIncome);
            int dependentsScore = CalculateDependentsScore(numberOfDependents);

            return incomeScore + dependentsScore;
        }

        private static int CalculateIncomeScore(decimal totalIncome)
        {
            const int IncomeBelow900Score = 5;
            const int IncomeBetween900And1500Score = 3;
            const int DefaultScore = 0;

            return totalIncome <= 900 ? IncomeBelow900Score :
                   totalIncome <= 1500 ? IncomeBetween900And1500Score :
                   DefaultScore;
        }

        private static int CalculateDependentsScore(int numberOfDependents)
        {
            const int ThreeOrMoreDependentsScore = 3;
            const int OneOrTwoDependentsScore = 2;
            const int DefaultScore = 0;

            return numberOfDependents >= 3 ? ThreeOrMoreDependentsScore :
                   numberOfDependents >= 1 ? OneOrTwoDependentsScore :
                   DefaultScore;
        }
    }
}
