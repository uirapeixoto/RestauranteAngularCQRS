using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class GarcomListQueryHandler : IQueryHandler<IEnumerable<GarcomQueryResult>>
    {
        private ICafeContext _context;
        public GarcomListQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<GarcomQueryResult> Handle()
        {
            try
            {
                var result = _context.TbWaitstaff
                                .AsNoTracking()
                                .AsParallel()
                                .Select(e => new GarcomQueryResult(
                                    e.Id,
                                    e.DsName))
                                .ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
