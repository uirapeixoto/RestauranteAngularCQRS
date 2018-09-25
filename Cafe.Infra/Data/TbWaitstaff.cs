using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbWaitstaff
    {
        public TbWaitstaff()
        {
            TbTabOpened = new HashSet<TbTabOpened>();
        }

        public int Id { get; set; }
        public string DsName { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }

        public ICollection<TbTabOpened> TbTabOpened { get; set; }
    }
}
