using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Cafe.Query.Query;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Garcon")]
    public class GarconController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<GarcomViewModel> Listar()
        {
            try
            {
                using (var garcons = new GarcomListQueryHandler())
                {
                    var result = new List<int>();

                    return garcons.Handle().Select(i => new GarcomViewModel
                    {
                        Id = i.Id,
                        Nome = i.Nome,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet("[action]/{id}")]
        public IEnumerable<MesaAbertaViewModel> Tarefa(int id)
        {
            try
            {
                using (var garconTarefas = new GarconsTarefasQueryHandler())
                {
                    return garconTarefas.Handle(new GarconsTarefasQuery(id))
                                .Select(x => new MesaAbertaViewModel
                                {
                                    Id = x.Id,
                                    NumMesa = x.NumMesa,
                                    Garcom = new GarcomViewModel
                                    {
                                        Id = x.Garcom.Id,
                                        Nome = x.Garcom.Nome
                                    },
                                    DataServico = x.DataServico.HasValue ? x.DataServico.Value.ToString("d") : "",
                                    Pedidos = x.Pedidos.Select(p => new PedidoViewModel
                                    {
                                        Id = p.Id,
                                        PedidoBebidaItens = p.ItensPedidos.Where(f => f.MenuItem.Bebida).Select(i => new PedidoItemViewModel
                                        {
                                            Id = i.Id,
                                            MenuItem = new MenuItemViewModel
                                            {
                                                Id = i.MenuItem.Id,
                                                NumMenuItem = i.MenuItem.NumMenuItem,
                                                Descricao = i.MenuItem.Descricao,
                                                Ativo = i.MenuItem.Ativo
                                            },
                                            AServir = i.AServir.HasValue ? i.AServir.Value.ToString("d") : "",
                                            EmPreparacao = i.EmPreparacao.HasValue ? i.EmPreparacao.Value.ToString("d") : "",
                                            Servido = i.Servido.HasValue ? i.Servido.Value.ToString("d") : "",
                                            Quantidade = i.Quantidade,
                                            Descricao = i.Descricao,
                                        }).ToList(),
                                        PedidoComidaItens = p.ItensPedidos.Where(f => !f.MenuItem.Bebida).Select(i => new PedidoItemViewModel
                                        {
                                            Id = i.Id,
                                            MenuItem = new MenuItemViewModel
                                            {
                                                Id = i.MenuItem.Id,
                                                NumMenuItem = i.MenuItem.NumMenuItem,
                                                Descricao = i.MenuItem.Descricao,
                                                Ativo = i.MenuItem.Ativo
                                            },
                                            AServir = i.AServir.HasValue ? i.AServir.Value.ToString("d") : "",
                                            EmPreparacao = i.EmPreparacao.HasValue ? i.EmPreparacao.Value.ToString("d") : "",
                                            Servido = i.Servido.HasValue ? i.Servido.Value.ToString("d") : "",
                                            Quantidade = i.Quantidade,
                                            Descricao = i.Descricao,
                                        }).ToList(),
                                    }),
                                    Ativo = x.Ativo
                                });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}