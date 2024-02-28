using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Transferlog> GetTransferLogs()
        {
            return _ctx.Transferlog.ToList(); // Ensure you are calling ToList() if Transferlog is a DbSet
        }

        // Implement the Add method as required by the interface
        public void Add(Transferlog transferLog)
        {
            _ctx.Transferlog.Add(transferLog);
            _ctx.SaveChanges();
        }
    }
}
