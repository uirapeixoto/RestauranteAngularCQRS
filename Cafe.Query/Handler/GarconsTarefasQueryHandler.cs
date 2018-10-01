using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Query;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class GarconsTarefasQueryHandler : IDisposable
    {

        public void Dispose()
        {
        }

        public IEnumerable<MesaAbertaQueryResult> Handle(GarconsTarefasQuery query)
        {
            try
            {
                using (var _context = new CafeContext())
                {
                    var mesas = _context.TbTabOpened
                                 .AsNoTracking()
                                 .Where(e => e.StActive)
                                 .Where(g => g.IdWaiter == query.Id)
                                 .Include(p => p.TbOrdered)
                                 .Include(p => p.TbOrdered)
                                 .Include(p => p.IdWaiterNavigation)
                                 .AsParallel()
                                 .Select(o => new MesaAbertaQueryResult(
                                         o.Id,
                                         o.NuTable.Value,
                                         new GarcomQueryResult(o.IdWaiterNavigation.Id, o.IdWaiterNavigation.DsName),
                                         o.TbOrdered.Where(x => x.TbOrderedItem.Any()).Select(
                                             p => new PedidoQueryResult(
                                             p.Id,
                                             p.TbOrderedItem
                                             .Where(x => !x.DtServed.HasValue)
                                             .Select(i => new PedidoItemQueryResult(
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
                                                     i.DsDescription
                                             ))
                                         )),
                                         o.DtService,
                                         o.StActive
                                 )).ToList();

                    return mesas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
