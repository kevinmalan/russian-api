using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhrasesController(IPhraseService phraseService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await phraseService.GetAsync();

            return Ok(result);
        }
    }
}