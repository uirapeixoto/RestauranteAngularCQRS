using Cafe.Contract;
using System.Collections.Generic;

namespace Cafe.Query.Result
{
    public sealed class PainelInicialQueryResult : IQueryResult
    {
        public Dictionary<int, string> Garcon { get; }
        public Dictionary<int, int> Mesas { get; }

        public PainelInicialQueryResult(Dictionary<int, string> garcon, Dictionary<int, int> mesas)
        {
            Garcon = garcon;
            Mesas = mesas;
        }
    }
}
