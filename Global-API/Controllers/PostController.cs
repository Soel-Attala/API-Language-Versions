using Microsoft.Extensions.Localization;
using Global_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Global_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IStringLocalizer<PostController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourcesLocalizer;



        public PostController(IStringLocalizer<PostController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourcesLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourcesLocalizer = sharedResourcesLocalizer;
        }

        [HttpGet]
        [Route("PostControllerResources")]
        public IActionResult GetUsingPostControllerResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
            });
        }

        [HttpGet]
        [Route("SharedResources")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            var TodayIs = string.Format(_sharedResourcesLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = TodayIs,
            });
        }






    }
}
