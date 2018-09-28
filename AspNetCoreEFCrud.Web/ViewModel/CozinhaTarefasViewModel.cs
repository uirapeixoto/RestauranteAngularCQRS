using System;
using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class CozinhaTarefasViewModel
    {
        public int PedidoItemId { get; set; }
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal AjustePrco { get; set; }
        public string AServir { get; set; }
        public string EmPreparacao { get; set; }
        public string Servido { get; set; }
        public MenuItemViewModel MenuItem { get; set; }

        public IList<PedidoItemViewModel> PedidosProntos { get; set; }

        public IList<PedidoItemViewModel> PedidosSolicitados(IList<PedidoItemViewModel> pedidos)
        {
            return pedidos;
        }

        public bool MarcarComoPronto
        {
            get
            {
                return (!string.IsNullOrEmpty(AServir));
            }
            set
            {
                if (value)
                {
                    AServir = DateTime.Now.ToString("d");
                }
            }
        }
    }
}
