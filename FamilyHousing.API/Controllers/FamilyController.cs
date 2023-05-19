using FamilyHousing.Domain.Contracts.Services;
using FamilyHousing.Domain.Entities;
using FamilyHousing.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyHousing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateFamily(FamilyModel family)
        {
            var model = await _familyService.Add(family);

            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _familyService.GetbyId(id);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _familyService.GetAll();

            return Ok(model);
        }

        [HttpGet("ListEligibleFamilies")]
        public async Task<IActionResult> GetListEligibleFamilies()
        {
            var model = await _familyService.GetListEligibleFamilies();

            return Ok(model);
        }
    }
}
