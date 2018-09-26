using System;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class PedidoItemViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal AjustePreco { get; set; }
        public DateTime? AServir { get; set; }
        public DateTime? EmPreparacao { get; set; }
        public DateTime? Servido { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
    }
}
