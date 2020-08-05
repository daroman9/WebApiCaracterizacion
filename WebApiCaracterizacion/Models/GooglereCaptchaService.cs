using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class GooglereCaptchaService
    {
    
        public virtual async Task<GoogleRespo> VerifyCaptcha(string _Token, string _SecretKey)
        {
            GooglereCaptchaData _MyData = new GooglereCaptchaData
            {
                response = _Token,
                secret = _SecretKey
            };

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?=secret{_MyData.secret}&response={_MyData.response}");

            var capresp = JsonConvert.DeserializeObject<GoogleRespo>(response);

            return capresp;

        }
    }

    public class GooglereCaptchaData
    {
        public string response { get; set; } //Token
        public string secret { get; set; }
    }

    public class GoogleRespo
    {
        public bool success { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}
