﻿using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Cafe.Query.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Cozinha")]
    public class CozinhaController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<CozinhaTarefasViewModel> Listar()
        {
            using (var cozinhaTarefas = new CozinhaTarefasQueryHandler())
            {
                var result = cozinhaTarefas.Handle(new CozinhaTarefasQuery(0))
                    .Select(o => new CozinhaTarefasViewModel
                    {
                        PedidoItemId = o.PedidoItemId,
                        MesaId = o.MesaId,
                        PedidoId = o.PedidoId,
                        MenuItem = new MenuItemViewModel
                        {
                            Id = o.MenuItem.Id,
                            NumMenuItem = o.MenuItem.NumMenuItem,
                            Descricao = o.MenuItem.Descricao,
                            Bebida = o.MenuItem.Bebida,
                            Ativo = o.MenuItem.Ativo
                        },
                        Quantidade = o.Quantidade,
                        Descricao = o.Descricao,
                        AServir = o.AServir.HasValue ? o.AServir.Value.ToString("d") : "",
                        EmPreparacao = o.EmPreparacao.HasValue ? o.EmPreparacao.Value.ToString("d") : "",
                        Servido = o.Servido.HasValue ? o.Servido.Value.ToString("d") : ""
                    }).ToList();

                var _refeicoesProntas = result
                    .Where(x => !string.IsNullOrEmpty(x.AServir))
                    .OrderBy(o => o.PedidoItemId).ToList();

                ViewBag.RefeicoesProntas = _refeicoesProntas.Count() > 0 ? _refeicoesProntas : new List<CozinhaTarefasViewModel>();

                return result.Where(x => string.IsNullOrEmpty(x.AServir)).ToList();
            }
        }
    }
}