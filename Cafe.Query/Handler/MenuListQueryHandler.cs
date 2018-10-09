using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public sealed class MenuListQueryHandler : IQueryHandler<IEnumerable<MenuItemQueryResult>>, IDisposable
    {
        public void Dispose()
        {
        }

        public IEnumerable<MenuItemQueryResult> Handle()
        {
            try
            {
                using (var _context = new CafeContext())
                {
                    return _context.TbMenuItem
                        .AsNoTracking()
                        .Where(x => x.StActive)
                        .AsParallel()
                        .Select(x => new MenuItemQueryResult(
                    x.Id,
                    x.NuMenuItem,
                    x.DsDescription,
                    x.NuPrice,
                    x.StIsDrink,
                    x.StActive
                )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
