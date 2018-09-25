using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbTabClosed
    {
        public int Id { get; set; }
        public decimal? NuAmountPaid { get; set; }
        public decimal? NuOrderValue { get; set; }
        public decimal? NuTipValue { get; set; }
        public DateTime? DtService { get; set; }
    }
}
