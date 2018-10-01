using AspNetCoreEFCrud.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreEFCrud.Web.Helper
{
    public static class Util
    {
        public static MesaStatusViewModel AgregarPedidos(IList<PedidoViewModel> pedidos)
        {
            var pedidosAServir = new List<PedidoItemViewModel>();
            var pedidosComidaEmPreparacao = new List<PedidoItemViewModel>();
            var pedidosServidos = new List<PedidoItemViewModel>();


            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoBebidaItens.Where(x => string.IsNullOrEmpty(x.Servido)))
                {
                    pedidosAServir.Add(item);
                }
            }

            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoComidaItens.Where(x => !string.IsNullOrEmpty(x.EmPreparacao) && string.IsNullOrEmpty(x.Servido) && !x.MenuItem.Bebida))
                {
                    pedidosComidaEmPreparacao.Add(item);
                }
            }

            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoBebidaItens.Where(x => !string.IsNullOrEmpty(x.Servido)))
                {
                    pedidosServidos.Add(item);
                }
                foreach (var item in pedido.PedidoComidaItens.Where(x => !string.IsNullOrEmpty(x.Servido)))
                {
                    pedidosServidos.Add(item);
                }
            }

            var pedidosItensConsolidados = new MesaStatusViewModel
            {
                PedidosAServir = pedidosAServir,
                PedidosEmPreparacao = pedidosComidaEmPreparacao,
                PedidosServidos = pedidosServidos
            };

            return pedidosItensConsolidados;
        }
    }
}
