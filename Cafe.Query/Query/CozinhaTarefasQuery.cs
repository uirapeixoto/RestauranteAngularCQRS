using Cafe.Contract;

namespace Cafe.Query.Query
{
    public class CozinhaTarefasQuery : IQuery
    {
        public int Id { get; }
        public CozinhaTarefasQuery(int id)
        {
            Id = id;
        }
    }
}
