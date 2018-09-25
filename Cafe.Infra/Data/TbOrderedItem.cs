using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbOrderedItem
    {
        public int Id { get; set; }
        public int IdMenuItem { get; set; }
        public int IdOrdered { get; set; }
        public int NuAmount { get; set; }
        public decimal? NuPriceAdjustiment { get; set; }
        public DateTime? DtToServe { get; set; }
        public DateTime? DtInPreparation { get; set; }
        public DateTime? DtServed { get; set; }
        public string DsDescription { get; set; }
        public DateTime DtService { get; set; }

        public TbMenuItem IdMenuItemNavigation { get; set; }
        public TbOrdered IdOrderedNavigation { get; set; }
    }
}
