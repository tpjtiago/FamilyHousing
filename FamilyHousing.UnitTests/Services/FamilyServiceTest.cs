using AutoMapper;
using FamilyHousing.Domain.AutoMapper;
using FamilyHousing.Domain.Contracts.Repositories;
using FamilyHousing.Domain.Entities;
using FamilyHousing.Domain.Models;
using FamilyHousing.Domain.Services;
using Moq;

namespace FamilyHousing.UnitTests.Services
{
    public class FamilyServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Family>> _repositoryMock;
        public FamilyServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new FamilyProfile()));
            _mapper = mapperConfig.CreateMapper();

            _repositoryMock = new Mock<IRepository<Family>>();
        }
        [Fact]
        public async Task Add_ShouldAddFamilyAndReturnResult()
        {
            // Arrange
            var familyModel = new FamilyModel
            {
                Name = "Família Silva",
                TotalIncome = 800,
                NumberOfDependents = 3,
                Score = 8
            };

            var expectedFamily = new Family
            {
                Id = 1,
                Name = "Família Silva",
                TotalIncome = 800,
                NumberOfDependents = 3
            };

            _repositoryMock.Setup(r => r.Add(It.IsAny<Family>()))
                .ReturnsAsync(expectedFamily);

            var familyService = new FamilyService(_mapper, _repositoryMock.Object);

            // Act
            var result = await familyService.Add(familyModel);

            // Assert
            Assert.Equal(expectedFamily, result);
            _repositoryMock.Verify(r => r.Add(It.IsAny<Family>()), Times.Once);
        }
        [Fact]
        public async Task GetbyId_ShouldGetFamilyAndMapToModel()
        {
            // Arrange
            var familyId = 1;
            var expectedFamily = new Family
            {
                Id = 1,
                Name = "Família Silva",
                TotalIncome = 2000,
                NumberOfDependents = 2
            };

            _repositoryMock.Setup(r => r.Get(familyId))
                .ReturnsAsync(expectedFamily);

            var familyService = new FamilyService(_mapper, _repositoryMock.Object);

            // Act
            var result = await familyService.GetbyId(familyId);

            // Assert
            Assert.Equal(expectedFamily.Name, result.Name);
            Assert.Equal(expectedFamily.TotalIncome, result.TotalIncome);
            Assert.Equal(expectedFamily.NumberOfDependents, result.NumberOfDependents);
        }

        [Fact]
        public async Task GetAll_ShouldGetAllFamiliesAndMapToListOfModels()
        {
            // Arrange
            var expectedFamilies = new List<Family>
            {
                new Family
                {
                    Id = 1,
                    Name = "Família Silva",
                    TotalIncome = 1000,
                    NumberOfDependents = 2
                },
                new Family
                {
                    Id = 2,
                    Name = "Família Souza",
                    TotalIncome = 3000,
                    NumberOfDependents = 1
                }
            };

            _repositoryMock.Setup(r => r.GetAll())
                .ReturnsAsync(expectedFamilies);

            var familyService = new FamilyService(_mapper, _repositoryMock.Object);

            // Act
            var result = await familyService.GetAll();

            // Assert
            Assert.Equal(expectedFamilies.Count, result.Count);

            for (int i = 0; i < expectedFamilies.Count; i++)
            {
                Assert.Equal(expectedFamilies[i].Name, result[i].Name);
                Assert.Equal(expectedFamilies[i].TotalIncome, result[i].TotalIncome);
                Assert.Equal(expectedFamilies[i].NumberOfDependents, result[i].NumberOfDependents);
            }
        }

        [Fact]
        public async Task GetListEligibleFamilies_ShouldReturnSortedEligibleFamilies()
        {
            // Arrange
            var expectedFamilies = new List<Family>
            {
                new Family
                {
                    Id = 1,
                    Name = "Família Silva",
                    TotalIncome = 2000,
                    NumberOfDependents = 2
                },
                new Family
                {
                    Id = 2,
                    Name = "Família Souza",
                    TotalIncome = 3000,
                    NumberOfDependents = 1
                }
            };

            var expectedFamilyModels = expectedFamilies
                .Select(f => new FamilyModel
                {
                    Name = f.Name,
                    TotalIncome = f.TotalIncome,
                    NumberOfDependents = f.NumberOfDependents,
                    Score = 2 // Alterar 0 se for raelizar o teste de regressão 
                })
                .ToList();

            var expectedOrder = expectedFamilyModels
                .OrderByDescending(p => p.Score)
                .ThenBy(p => p.TotalIncome)
                .ToList();

            _repositoryMock.Setup(r => r.GetAll())
                .ReturnsAsync(expectedFamilies);

            var familyService = new FamilyService(_mapper, _repositoryMock.Object);

            // Act
            var result = await familyService.GetListEligibleFamilies();

            // Assert
            Assert.Equal(expectedOrder.Count, result.Count);

            for (int i = 0; i < expectedOrder.Count; i++)
            {
                Assert.Equal(expectedOrder[i].Name, result[i].Name);
                Assert.Equal(expectedOrder[i].TotalIncome, result[i].TotalIncome);
                Assert.Equal(expectedOrder[i].NumberOfDependents, result[i].NumberOfDependents);
                Assert.Equal(expectedOrder[i].Score, result[i].Score);
            }
        }
    }
}
