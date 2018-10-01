using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class MesaStatusViewModel
    {
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public IList<PedidoItemViewModel> PedidosAServir { get; set; }
        public IList<PedidoItemViewModel> PedidosEmPreparacao { get; set; }
        public IList<PedidoItemViewModel> PedidosServidos { get; set; }

        public MesaStatusViewModel()
        {
            PedidosAServir = new List<PedidoItemViewModel>();
            PedidosEmPreparacao = new List<PedidoItemViewModel>();
            PedidosServidos = new List<PedidoItemViewModel>();
        }
    }
}
