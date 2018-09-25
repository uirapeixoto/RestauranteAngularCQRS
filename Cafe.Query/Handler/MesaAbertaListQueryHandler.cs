﻿using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cafe.Query.Handler
{
    public class MesaAbertaListQueryHandler : IQueryHandler<IEnumerable<MesaAbertaQueryResult>>
    {
        private ICafeContext _context;
        public MesaAbertaListQueryHandler(ICafeContext context)
        {
            _context = context;
        }
        public IEnumerable<MesaAbertaQueryResult> Handle()
        {
            try
            {
                var result = _context.TbTabOpened
                .Include(p => p.TbOrdered)
                .Include(g => g.IdWaiterNavigation)
                .AsNoTracking()
                .Where(e => e.StActive)
                .AsParallel()
                .Select(o => new MesaAbertaQueryResult(
                    o.Id,
                    o.NuTable.Value,
                    new GarcomQueryResult(o.IdWaiterNavigation.Id, o.IdWaiterNavigation.DsName),
                    null,
                    o.DtService,
                    o.StActive
                    )).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
