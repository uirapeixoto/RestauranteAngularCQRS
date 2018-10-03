using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class CozinhaViewModel
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
