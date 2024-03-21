using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using static API.Mappers.PhraseMapper;

namespace API.Controllers
{
    public class PhrasesController(IPhraseService phraseService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var models = await phraseService.GetAsync();
            var dto = models.Select(x => x.MapToDto()).ToList(); ;

            return Ok(dto);
        }
    }
}