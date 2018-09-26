using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class PedidoViewModel
    {
        public int Id { get; }
        public IEnumerable<PedidoItemViewModel> ItensPedidos { get; set; }
    }
}
