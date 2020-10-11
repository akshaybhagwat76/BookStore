using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
    public class CaptchaGoogle
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
