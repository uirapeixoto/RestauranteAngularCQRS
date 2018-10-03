using System;
using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.ViewModel
{
    public class CozinhaTarefasViewModel
    {
        public IEnumerable<CozinhaViewModel>TarefasPendente { get; set; }
        public IEnumerable<CozinhaViewModel>TarefasPronta { get; set; }

        public CozinhaTarefasViewModel()
        {
            TarefasPendente = new List<CozinhaViewModel>();
            TarefasPronta = new List<CozinhaViewModel>();
        }
        
    }
}
