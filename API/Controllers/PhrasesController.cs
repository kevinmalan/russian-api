using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhrasesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new
            {
                Todo = true
            });
        }
    }
}
