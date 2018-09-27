using Cafe.Infra.Data;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cafe.AppConsole
{
    class Program
    {



        static void Main(string[] args)
        {
                GetMesasAbertas();
                Console.ReadKey();
        }

        public static void GetMesasAbertas() {

            using (CafeContext db = new CafeContext())
            {
                var mesas = db.TbTabOpened
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

                foreach (var item in mesas)
                {
                    Console.WriteLine(string.Format("Garçon: {0} - Mesa: {1}", item.Garcom.Nome, item.NumMesa));

                }
                
            }
        }
    }
}
