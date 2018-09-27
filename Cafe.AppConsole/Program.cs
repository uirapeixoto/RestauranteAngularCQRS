using Cafe.Infra.Data;
using System;
using System.Linq;

namespace Cafe.AppConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            using (CafeContext db = new CafeContext())
            {
                var pedidos = db.TbOrdered.Select(o => new
                { 
                    o.Id,
                    o.DtService
                });

                foreach(var item in pedidos)
                {
                    Console.WriteLine(string.Format("Pedido:{0}", item.Id));
                }
                Console.ReadKey();
            }
        }
    }
}
