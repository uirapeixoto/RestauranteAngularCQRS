using Cafe.Contract;

namespace Cafe.Query.Query
{
    public class GarcomQuery : IQuery
    {
        public int Id { get; }

        public GarcomQuery(int id)
        {
            Id = id;
        }
    }
}
