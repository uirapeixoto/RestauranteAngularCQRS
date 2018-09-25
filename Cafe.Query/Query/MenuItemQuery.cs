using Cafe.Contract;

namespace Cafe.Query.Query
{
    public class MenuItemQuery : IQuery
    {
        private int Id { get; }

        public MenuItemQuery(int id)
        {
            Id = id;
        }
    }
}
