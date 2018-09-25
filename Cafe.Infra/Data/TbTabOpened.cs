using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbTabOpened
    {
        public TbTabOpened()
        {
            TbOrdered = new HashSet<TbOrdered>();
            TbTodo = new HashSet<TbTodo>();
        }

        public int Id { get; set; }
        public int? NuTable { get; set; }
        public int? IdWaiter { get; set; }
        public bool StActive { get; set; }
        public DateTime? DtService { get; set; }
        public Guid? StUniqueIdentifier { get; set; }

        public TbWaitstaff IdWaiterNavigation { get; set; }
        public ICollection<TbOrdered> TbOrdered { get; set; }
        public ICollection<TbTodo> TbTodo { get; set; }
    }
}
