using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AspNetCoreEFCrud.Web.Helper;
using AspNetCoreEFCrud.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Cafe.Command.Command;
using Cafe.Command.Handler;
using Cafe.Query.Handler;
using Cafe.Query.Query;


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
        public HttpResponseMessage AbrirNovaMesa([FromBody]MesaNovaViewModel value)
        {
            try
            {
                var guid = Guid.NewGuid();

                using (var abrirNovaMesaHandler = new AbrirNovaMesaCommandHandler())
                {
                    abrirNovaMesaHandler.Handle(new AbrirNovaMesaCommand(value.NumMesa, value.GarcomId));

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.Ambiguous);
            }
        }

        [HttpGet("[action]/{id}")]
        public PedidoViewModel Pedido(int id)
        {
            try
            {
                using (var _menuItemQueryHandler = new MenuListQueryHandler())
                {
                    var menu = _menuItemQueryHandler.Handle().Select(o => new MenuItemViewModel
                    {
                        Id = o.Id,
                        NumMenuItem = o.NumMenuItem,
                        Descricao = o.Descricao,
                        Bebida = o.Bebida,
                    });

                    return new PedidoViewModel
                    {
                        MesaId = id,
                        PedidoBebidaItens = menu.Where(x => x.Bebida).Select(m => new PedidoItemViewModel
                        {
                            MenuItem = new MenuItemViewModel
                            {
                                Id = m.Id,
                                NumMenuItem = m.NumMenuItem,
                                Descricao = m.Descricao,
                                Bebida = m.Bebida,
                                Ativo = m.Ativo
                            }
                        }).OrderBy(x => x.MenuItem.NumMenuItem).ToList(),
                        PedidoComidaItens = menu.Where(x => !x.Bebida).Select(m => new PedidoItemViewModel
                        {
                            MenuItem = new MenuItemViewModel
                            {
                                Id = m.Id,
                                NumMenuItem = m.NumMenuItem,
                                Descricao = m.Descricao,
                                Bebida = m.Bebida,
                                Ativo = m.Ativo
                            }
                        }).OrderBy(x => x.MenuItem.NumMenuItem).ToList()
                    };
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}