using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cafe.Contract;
using Cafe.Domain.Mesa;
using Cafe.Query.Result;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Route("api/[controller]")]
    public class MesaController : Controller
    {
        readonly IQueryHandler<IEnumerable<MesaAbertaQueryResult>> ObterMesasAtivasQueryHandler;

        public MesaController(IQueryHandler<IEnumerable<MesaAbertaQueryResult>> obterMesasAtivasQueryHandler)
        {
            ObterMesasAtivasQueryHandler = obterMesasAtivasQueryHandler;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> MesasAbertas()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

    }
}