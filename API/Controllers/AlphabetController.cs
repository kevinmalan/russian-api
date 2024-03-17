using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AlphabetController(IAlphabetService alphabetService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await alphabetService.GetAsync();

            return Ok(result);
        }
    }
}