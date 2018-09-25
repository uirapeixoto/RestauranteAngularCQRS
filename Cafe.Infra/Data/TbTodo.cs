using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbTodo
    {
        public int Id { get; set; }
        public int IdTabOpened { get; set; }
        public int IdOrdered { get; set; }
        public DateTime? DtService { get; set; }

        public TbTabOpened IdTabOpenedNavigation { get; set; }
    }
}
