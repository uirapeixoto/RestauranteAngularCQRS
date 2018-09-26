namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public int NumMenuItem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Bebida { get; set; }
        public bool Ativo { get; set; }
    }
}
