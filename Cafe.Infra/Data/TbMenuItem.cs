using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbMenuItem
    {
        public TbMenuItem()
        {
            TbOrderedItem = new HashSet<TbOrderedItem>();
        }

        public int Id { get; set; }
        public int NuMenuItem { get; set; }
        public string DsDescription { get; set; }
        public decimal NuPrice { get; set; }
        public bool StIsDrink { get; set; }
        public bool StActive { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }

        public ICollection<TbOrderedItem> TbOrderedItem { get; set; }
    }
}
