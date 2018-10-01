using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Painel")]
    public class PainelController : Controller
    {
        // GET: api/Painel
        [HttpGet("[action]")]
        public PainelInicialViewModel Inicial()
        {
            using (var painel = new PainelInicialQueryHandler())
            {
                var result = new PainelInicialViewModel();
                var handle = painel.Handle();

                result.Garcon = handle.Garcon;
                result.Mesas = handle.Mesas;

                return result;
            }
        }
    }
}
