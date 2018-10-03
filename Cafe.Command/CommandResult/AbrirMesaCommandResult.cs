﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Command.CommandResult
{
    public class AbrirMesaCommandResult
    {
        public int Id { get; }
        public int NumMesa { get; }
        public int GarcomId { get; }
        public bool Ativo { get; }
        public DateTime DataServico { get; }

        public AbrirMesaCommandResult(int id, int numMesa, int garcomId, bool ativo, DateTime DataServio)
        {
            Id = id;
            NumMesa = numMesa;
            GarcomId = garcomId;
            Ativo = ativo;
            DataServico = DataServio;
        }
    }
}