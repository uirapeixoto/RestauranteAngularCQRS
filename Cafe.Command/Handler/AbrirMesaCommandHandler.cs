using Cafe.Command.Command;
using Cafe.Command.CommandResult;
using Cafe.Contract;
using Cafe.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cafe.Command.Handler
{
    public class AbrirMesaCommandHandler : ICommandHandler<AbrirMesaCommand, AbrirMesaCommandResult>, IDisposable
    {

        readonly ICafeContext _context;

        public AbrirMesaCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        public bool Validacao(int numMesa)
        {
            return !_context.TbTabOpened
            .Where(x => x.NuTable == numMesa)
            .Where(x => x.StActive).Any();
        }

        public AbrirMesaCommandResult Handle(AbrirMesaCommand c)
        {
            try
            {
                if (Validacao(c.NumMesa))
                {
                    var table = new TbTabOpened
                    {
                        NuTable = c.NumMesa,
                        IdWaiter = c.GarcomId,
                        StActive = c.Ativo,
                        DtService = c.DataServico,
                        StUniqueIdentifier = Guid.NewGuid()
                    };

                    _context.TbTabOpened.Add(table);
                    var id = _context.SaveChanges();

                    return _context.TbTabOpened
                        .AsNoTracking()
                        .AsParallel()
                        .Where(x => x.Id == table.Id)
                        .Select(o => new AbrirMesaCommandResult(o.Id, o.NuTable.Value, o.IdWaiter.Value, o.StActive, o.DtService.Value))
                        .FirstOrDefault();
                }
                else
                {
                    throw new Exception("Essa mesa já está aberta");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
        }
    }
}
