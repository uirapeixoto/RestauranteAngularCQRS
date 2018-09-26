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
    [Produces("application/json")]
    [Route("api/Mesas")]
    public class MesaController : Controller
    {
        readonly IQueryHandler<IEnumerable<MesaAbertaQueryResult>> ObterMesasAtivasQueryHandler;

        public MesaController(IQueryHandler<IEnumerable<MesaAbertaQueryResult>> obterMesasAtivasQueryHandler)
        {
            ObterMesasAtivasQueryHandler = obterMesasAtivasQueryHandler;
        }

        [HttpGet("[action]")]
        public IEnumerable<int> MesasAbertas()
        {
            var rng = new Random();

            var MesasAbertas = ObterMesasAtivasQueryHandler.Handle().Select(i => i.Id);

            return MesasAbertas;
        }

    }
}