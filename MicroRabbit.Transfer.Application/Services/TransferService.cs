using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Application.Interfaces
{
    public class TransferService : ITransferService
    {
      public readonly ITransferRepository _transferRepository;
      public readonly IEventBus _bus;

      public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }
      public IEnumerable<Transferlog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }

    }
}
