using Cafe.Contract;

namespace Cafe.Query.Query
{
    public class MesaAbertaQuery : IQuery
    {
        public int Id { get; }
        public int NumMesa { get; }

        public MesaAbertaQuery(int id = 0, int numMesa = 0)
        {
            Id = id;
            NumMesa = numMesa;
        }
    }
}
