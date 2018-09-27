using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class GarcomListQueryHandler : IDisposable
    {

        public IEnumerable<GarcomQueryResult> Handle()
        {
            try
            {
                using (var context = new CafeContext())
                {
                    var result = context.TbWaitstaff
                                    .AsNoTracking()
                                    .AsParallel()
                                    .Select(e => new GarcomQueryResult(
                                        e.Id,
                                        e.DsName))
                                    .ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
        }
    }
}
