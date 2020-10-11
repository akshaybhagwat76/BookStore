using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeForFun.UI.WebMvcCore.Models.ViewModels;
using CodeForFun.UI.WebMvcCore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
    [Produces("application/json")]
    [Route("api/GoogleReCaptcha")]
    public class GoogleReCaptchaController : Controller
    {

        private readonly ILogger<GoogleReCaptchaController> _logger;

        public GoogleReCaptchaController(ILogger<GoogleReCaptchaController> logger)
        {
            _logger = logger;
        }
        
        [Route("ValidGoogleReCaptcha")]
        [HttpGet]
        public IActionResult ValidGoogleReCaptcha(string recaptchaResponse)
        {
            try
            {
                string path = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
                var client = new WebClient();
                var reply = client.DownloadString(string.Format(path, AppConsts.GoogleSecret, recaptchaResponse));
                var captchaResponse = JsonConvert.DeserializeObject<CaptchaGoogle>(reply);
                if (!captchaResponse.Success)
                {
                    return Ok(captchaResponse.ErrorCodes);
                }
                else
                {
                    return Ok("Success");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ToString());
            }
        }

    }
}