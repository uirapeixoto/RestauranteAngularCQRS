using Cafe.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Query.Result
{
    public class PedidosStatusQueryResult : IQueryResult
    {
        public int Id { get; }
        public int NumMesa { get; }
        public IEnumerable<PedidoItemQueryResult> ItensPedidos { get; }

        public PedidosStatusQueryResult(int id, int numMesa, IEnumerable<PedidoItemQueryResult> itensPedidos)
        {
            Id = id;
            NumMesa = numMesa;
            ItensPedidos = itensPedidos;
        }
    }
}
