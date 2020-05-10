using System.Collections.Generic;
using Newtonsoft.Json;


namespace vaynhanh3s.Domain.Response.ReCaptcha
{
    public class ReCaptcha
    {
        public ReCaptcha()
        {
            Success = false;
            ErrorCodes = new List<string>();
        }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
