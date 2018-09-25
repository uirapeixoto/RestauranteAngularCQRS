using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Contract;
using Cafe.Domain.Mesa;
using Cafe.Query.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreEFCrud.Web.ActionFilters
{
    public class IncludeLayoutDataAttribute : ActionFilterAttribute
    {
        readonly IQueryHandler<IEnumerable<GarcomQueryResult>> _garcomListHandler;

        readonly IQueryHandler<IEnumerable<MesaAbertaQueryResult>> _mesasAbertas;

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var bag = (filterContext.Result as ViewResult).TempData;
                var garcons = _garcomListHandler.Handle().AsParallel()
                    .Select(o => new GarcomViewModel
                    {
                        Id = o.Id,
                        Nome = o.Nome
                    }
                );
                var listaGarcons = new Dictionary<int, string>();
                
                foreach (var item in garcons)
                {
                    listaGarcons.Add(item.Id, item.Nome);
                }

                var mesas = _mesasAbertas.Handle();
                var listaMesas = new Dictionary<int, int>();

                foreach (var item in mesas)
                {
                    listaMesas.Add(item.Id, item.NumMesa);
                }
                bag.Add("Garcons",listaGarcons);
                bag.Add("ActiveTables", listaMesas);
                bag.Add("MesasAtivas", OpenTabQueries.ActiveTableNumbers);
            }
        }

    }
}
