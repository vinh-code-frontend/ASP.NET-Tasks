using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Task24SocialMediaLinks.Models;

namespace Task24SocialMediaLinks.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialMediaLinksOptions _socialMediaLinkOptions;
        public HomeController(IOptions<SocialMediaLinksOptions> socialMediaLinkOptions)
        {
            _socialMediaLinkOptions = socialMediaLinkOptions.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(_socialMediaLinkOptions);
        }
    }
}
