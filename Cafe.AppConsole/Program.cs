using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Handler;
using Cafe.Query.Query;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.AppConsole
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();

            typeof(MesaAbertaQueryHandler).Assembly.GetExportedTypes()
                            .Where(x => x.Namespace.EndsWith("Handler"))
                            .Where(x => x.GetInterfaces().Any())
                            .ToList()
                            .ForEach(x => container.Register(x.GetInterfaces().Single(), x, Lifestyle.Transient));

            container.Verify();
        }
        static void Main(string[] args)
        {
            var mesas = new ConsultarMesas();
            var result = mesas.MesasAbertas();

            Console.WriteLine(result);
        }
    }


    public class ConsultarMesas
    {
        readonly IQueryHandler<MesaAbertaQuery, IEnumerable<MesaAbertaQueryResult>> ObterMesasAtivasQueryHandler;

        public ConsultarMesas()
        {
        }

        public ConsultarMesas(IQueryHandler<MesaAbertaQuery, IEnumerable<MesaAbertaQueryResult>> obterMesasAtivasQueryHandler)
        {
            ObterMesasAtivasQueryHandler = obterMesasAtivasQueryHandler;
        }

        public IEnumerable<MesaAbertaQueryResult> MesasAbertas()
        {
            var result = ObterMesasAtivasQueryHandler.Handle(new MesaAbertaQuery(0, 0));
            return result;
        }
    }


}
