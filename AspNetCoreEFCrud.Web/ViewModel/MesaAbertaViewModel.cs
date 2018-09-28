using System;
using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class MesaAbertaViewModel
    {
        public int Id { get; set; }
        public int NumMesa { get; set; }
        public GarcomViewModel Garcom { get; set; }
        public IList<GarcomViewModel> Garcons { get; set; }
        public IEnumerable<PedidoViewModel> Pedidos { get; set; }
        public string DataServico { get; set; }
        public bool Ativo { get; set; }

        public MesaAbertaViewModel()
        {
            Pedidos = new List<PedidoViewModel>();
            Garcons = new List<GarcomViewModel>();
        }
    }
}
