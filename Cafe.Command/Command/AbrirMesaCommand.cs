﻿using Cafe.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Command.Command
{
    public class AbrirMesaCommand : ICommand
    {
        public int NumMesa { get; }
        public int GarcomId { get; }
        public bool Ativo { get; }
        public DateTime DataServico { get; }

        public AbrirMesaCommand(int numMesa, int garcomId)
        {
            NumMesa = numMesa;
            GarcomId = garcomId;
            Ativo = true;
            DataServico = DateTime.Now;
        }
    }
}
