using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Query;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class MesaAbertaQueryHandler : IQueryHandler<MesaAbertaQuery, MesaAbertaQueryResult>, IDisposable
    {
        public void Dispose()
        {
        }

        public MesaAbertaQueryResult Handle(MesaAbertaQuery query)
        {
            try
            {
                using (var _context = new CafeContext())
                {
                    var mesa = _context.TbTabOpened
                                .AsNoTracking()
                                .Where(e => ((query.Id > 0) && e.Id == query.Id) || ((query.NumMesa > 0) && e.NuTable == query.NumMesa))
                                .Where(e => e.StActive)
                                .Include(g => g.IdWaiterNavigation)
                                .Include(p => p.TbOrdered)
                                    .ThenInclude(pi => pi.TbOrderedItem)
                                    .ThenInclude(m => m.IdMenuItemNavigation)
                                .AsParallel()
                                .Select(o => new MesaAbertaQueryResult(
                                    o.Id,
                                    o.NuTable.Value,
                                    new GarcomQueryResult(o.IdWaiterNavigation.Id, o.IdWaiterNavigation.DsName),
                                    o.TbOrdered.Select(p => new PedidoQueryResult(
                                        p.Id,
                                        p.TbOrderedItem.Select(i => new PedidoItemQueryResult(
                                            i.Id,
                                            new MenuItemQueryResult(
                                                i.IdMenuItemNavigation.Id,
                                                i.IdMenuItemNavigation.NuMenuItem,
                                                i.IdMenuItemNavigation.DsDescription,
                                                i.IdMenuItemNavigation.NuPrice,
                                                i.IdMenuItemNavigation.StIsDrink,
                                                i.IdMenuItemNavigation.StActive),
                                            i.NuAmount,
                                            i.DtToServe,
                                            i.DtInPreparation,
                                            i.DtServed
                                            )))),
                                    o.DtService,
                                    o.StActive
                                    )).FirstOrDefault();

                    return mesa;
                }
            }
            catch (System.Exception)
            {

                throw;
            }


        }
    }
}
