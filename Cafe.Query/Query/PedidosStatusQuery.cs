using Cafe.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Query.Query
{
    public class PedidosStatusQuery : IQuery
    {
        public int IdMesa { get; }
        public int StatusServico { get; }

        public PedidosStatusQuery(int idMesa, int statusServico)
        {
            IdMesa = idMesa;
            StatusServico = statusServico;
        }
    }
}
