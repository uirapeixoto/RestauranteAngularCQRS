using System;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class PedidoItemViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal AjustePreco { get; set; }
        public string AServir { get; set; }
        public string EmPreparacao { get; set; }
        public string Servido { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
    }
}
