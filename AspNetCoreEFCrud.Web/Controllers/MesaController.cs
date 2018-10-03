using AspNetCoreEFCrud.Web.Helper;
using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Cafe.Query.Query;
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

        [HttpGet("[action]/{id}")]
        public MesaStatusViewModel Status(int id)
        {
            using (var mesaAberta = new MesaAbertaQueryHandler())
            {
                var mesa = mesaAberta.Handle(new MesaAbertaQuery(id, 0));
                var pedidos = mesa.Pedidos.Select(x => new PedidoViewModel
                {
                    Id = x.Id,
                    NumMesa = mesa.NumMesa,
                    PedidoBebidaItens = x.ItensPedidos.Where(b => b.MenuItem.Bebida).Select(i => new PedidoItemViewModel
                    {
                        Id = i.Id,
                        MenuItem = new MenuItemViewModel
                        {
                            Id = i.MenuItem.Id,
                            NumMenuItem = i.MenuItem.NumMenuItem,
                            Descricao = i.MenuItem.Descricao,
                            Valor = i.MenuItem.Valor,
                            Bebida = i.MenuItem.Bebida
                        },
                        Descricao = i.Descricao,
                        Quantidade = i.Quantidade,
                        Valor = (i.Quantidade * (double) i.MenuItem.Valor),
                        AServir = i.AServir.HasValue ? i.AServir.Value.ToString("d") : "",
                        EmPreparacao = i.EmPreparacao.HasValue ? i.EmPreparacao.Value.ToString("d") : "",
                        Servido = i.Servido.HasValue ? i.Servido.Value.ToString("d") : ""
                    }).ToList(),
                    PedidoComidaItens = x.ItensPedidos
                    .Where(b => !b.MenuItem.Bebida)
                    //.Where(b => !b.Servido.HasValue)
                    .Select(i => new PedidoItemViewModel
                    {
                        Id = i.Id,
                        MenuItem = new MenuItemViewModel
                        {
                            Id = i.MenuItem.Id,
                            NumMenuItem = i.MenuItem.NumMenuItem,
                            Descricao = i.MenuItem.Descricao,
                            Valor = i.MenuItem.Valor,
                            Bebida = i.MenuItem.Bebida
                        },
                        Descricao = i.Descricao,
                        Quantidade = i.Quantidade,
                        AServir = i.AServir.HasValue ? i.AServir.Value.ToString("d") : "",
                        EmPreparacao = i.EmPreparacao.HasValue ? i.EmPreparacao.Value.ToString("d") : "",
                        Servido = i.Servido.HasValue ? i.Servido.Value.ToString("d") : ""
                    }).ToList()
                }).ToList();

                var pedidosItensAgregados =  Util.AgregarPedidos(pedidos);
                var mesaStatus = new MesaStatusViewModel
                {
                    MesaId = mesa.Id,
                    NumMesa = mesa.NumMesa,
                    PedidosAServir = pedidosItensAgregados.PedidosAServir,
                    PedidosEmPreparacao = pedidosItensAgregados.PedidosEmPreparacao,
                    PedidosServidos = pedidosItensAgregados.PedidosServidos
                };

                return mesaStatus;
            }
        }

        [HttpPost("[action]")]
        public void AbrirNovaMesa([FromBody]MesaNovaViewModel value)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
            var result = value;

        }
    }
}