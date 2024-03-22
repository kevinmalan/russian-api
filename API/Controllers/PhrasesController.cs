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
            var dto = models.Select(x => x.MapToDto()).ToList();

            return Ok(dto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] Shared.Dtos.Phrase request)
        {
            var model = request.MapToModel();
            var newModel = await phraseService.CreateAsync(model);
            var dto = newModel.MapToDto();

            return Ok(dto);
        }
    }
}