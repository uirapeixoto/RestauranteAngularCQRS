using Cafe.Contract;
using System.Collections.Generic;

namespace Cafe.Query.Result
{
    public class GarcomTarefaQueryResult : IQueryResult
    {
        public int Id {get;}
        public string Nome { get; } 
        public IEnumerable<MesaAbertaQueryResult> Mesas { get; }

        public GarcomTarefaQueryResult(int id, string nome, IEnumerable<MesaAbertaQueryResult> mesas)
        {
            Id = id;
            Nome = nome;
            Mesas = mesas;
        }
    }
}
