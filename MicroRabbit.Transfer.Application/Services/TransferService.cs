﻿using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
      public readonly ITransferRepository transferRepository;
      public readonly IEventBus _bus;

      public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            this.transferRepository = transferRepository;
            _bus = bus;
        }
      public IEnumerable<TransferLog> GetTransferLogs()
        {
            return transferRepository.GetTransferLogs();
        }

    }
}
