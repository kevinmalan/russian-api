using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using static API.Mappers.AlphabetMapper;

namespace API.Controllers
{
    public class AlphabetController(IAlphabetService alphabetService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var models = await alphabetService.GetAsync();
            var dto = models.Select(x => x.MapToDto());

            return Ok(dto);
        }
    }
}