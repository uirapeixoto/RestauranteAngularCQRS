using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Mesa")]
    public class MesaController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<MesaAbertaViewModel> MesasAbertas()
        {
            using (var mesasAbertas = new MesaAbertaListQueryHandler())
            {
                var result = new List<int>();

                return mesasAbertas.Handle().Select(i => new MesaAbertaViewModel
                {
                    Id = i.Id,
                    NumMesa = i.NumMesa,
                    DataServico = i.DataServico.HasValue ? i.DataServico.Value.ToString("d") : "",
                    Ativo = i.Ativo,
                    Garcom = new GarcomViewModel
                    {
                        Id = i.Garcom.Id,
                        Nome = i.Garcom.Nome
                    },
                    Pedidos = new List<PedidoViewModel>()
                }).ToList();
            }
        }
    }
}