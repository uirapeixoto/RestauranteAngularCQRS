using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public sealed class PainelInicialQueryHandler : IDisposable
    {
        public void Dispose()
        {
        }

        public PainelInicialQueryResult Handle()
        {
            try
            {
                using (var _context = new CafeContext())
                {
                    var garcons = new Dictionary<int, string>();
                    var mesas = new Dictionary<int, int>();

                    garcons = _context.TbWaitstaff
                        .AsNoTracking()
                        .Where(i => i.TbTabOpened.Any())
                        .ToDictionary(d => d.Id, d => d.DsName);

                    mesas = _context.TbTabOpened
                        .AsNoTracking()
                        .Where(i => i.StActive)
                        .ToDictionary(d => d.Id, d => d.NuTable.Value);

                    return new PainelInicialQueryResult(garcons, mesas);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
