using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbOrdered
    {
        public TbOrdered()
        {
            TbOrderedItem = new HashSet<TbOrderedItem>();
        }

        public int Id { get; set; }
        public int IdTabOpened { get; set; }
        public DateTime? DtService { get; set; }

        public TbTabOpened IdTabOpenedNavigation { get; set; }
        public ICollection<TbOrderedItem> TbOrderedItem { get; set; }
    }
}
