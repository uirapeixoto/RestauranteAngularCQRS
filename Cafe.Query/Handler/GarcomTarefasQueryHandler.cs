using Cafe.Infra.Data;
using Cafe.Query.Query;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class GarcomTarefasQueryHandler : IDisposable
    {

        public void Dispose()
        {
        }

        public GarcomTarefaQueryResult Handle(GarconsTarefasQuery query)
        {
            try
            {
                using (var _context = new CafeContext())
                {
                    var garcom = _context.TbWaitstaff
                                 .AsNoTracking()
                                 .Where(g => g.Id == query.Id)
                                 .Include(p => p.TbTabOpened)
                                    .ThenInclude(o => o.TbOrdered)
                                        .ThenInclude(o => o.TbOrderedItem)
                                            .ThenInclude(m => m.IdMenuItemNavigation)
                                 .AsParallel()
                                 .Select(g => new GarcomTarefaQueryResult(
                                         g.Id,
                                         g.DsName,
                                         g.TbTabOpened.Where(x => x.StActive).Select(m => new MesaAbertaQueryResult
                                         (
                                             m.Id,
                                             m.NuTable.Value,
                                             new GarcomQueryResult (m.IdWaiterNavigation.Id, m.IdWaiterNavigation.DsName),
                                             m.TbOrdered.Where(x => x.TbOrderedItem.Any()).Select(p => new PedidoQueryResult(
                                                 p.Id,
                                                 p.TbOrderedItem.Where(x => !x.DtServed.HasValue).Select(i => new PedidoItemQueryResult(
                                                         i.Id,
                                                         new MenuItemQueryResult(
                                                             i.IdMenuItemNavigation.Id,
                                                             i.IdMenuItemNavigation.NuMenuItem,
                                                             i.IdMenuItemNavigation.DsDescription,
                                                             i.IdMenuItemNavigation.NuPrice,
                                                             i.IdMenuItemNavigation.StIsDrink,
                                                             i.IdMenuItemNavigation.StActive
                                                         ),
                                                         i.NuAmount,
                                                         i.DtToServe,
                                                         i.DtInPreparation,
                                                         i.DtServed,
                                                         i.DsDescription)
                                                    )
                                          )),
                                             m.DtService,
                                            m.StActive
                                         ))
                                 )).FirstOrDefault();

                    return garcom;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
