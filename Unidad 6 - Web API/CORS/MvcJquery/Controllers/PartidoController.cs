using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcJquery.Models;
using Newtonsoft.Json.Linq;

namespace MvcJquery.Controllers
{
    public class PartidoController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();

            var myObject = (dynamic)new JObject();
            myObject.Username = "asd";
            myObject.Password = "dsa";

            var content = new StringContent(myObject.ToString(), Encoding.UTF8, "application/json");
            var responseToken = await client.PostAsync("http://localhost:9100/api/token", content);

            if (responseToken.IsSuccessStatusCode)
            {
                var tokenResponse = await responseToken.Content.ReadAsStringAsync();


                //ErrorHelper.Log("LogInService: tokenResponse:" + tokenResponse);

                var json = JObject.Parse(tokenResponse);

                var token = json["token"].ToString();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("http://localhost:9100/api/partido");
                if (response.IsSuccessStatusCode)
                {
                    var partidos = await response.Content.ReadAsAsync<List<PartidoCompleto>>();
                    return View(partidos);
                }
            }

            

            return View();
        }

        public async Task<IActionResult> Index2()
        {
            return View();
        }
    }
}