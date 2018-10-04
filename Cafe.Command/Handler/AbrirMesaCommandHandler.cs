using Cafe.Command.Command;
using Cafe.Command.CommandResult;
using Cafe.Contract;
using Cafe.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cafe.Command.Handler
{
    public class AbrirNovaMesaCommandHandler : ICommandHandler<AbrirNovaMesaCommand, AbrirNovaMesaCommandResult>, IDisposable
    {

        public bool Validacao(int numMesa)
        {
            using (var _context = new CafeContext())
            {
                return !_context.TbTabOpened
                            .Where(x => x.NuTable == numMesa)
                            .Where(x => x.StActive).Any();
            }
        }

        public AbrirNovaMesaCommandResult Handle(AbrirNovaMesaCommand c)
        {
            try
            {
                using (var _context = new CafeContext())
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
                            .Select(o => new AbrirNovaMesaCommandResult(o.Id, o.NuTable.Value, o.IdWaiter.Value, o.StActive, o.DtService.Value))
                            .FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Essa mesa já está aberta");
                    }
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
