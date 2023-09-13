using AutoMapper;
using MassTransit;
using Payment.Application.Contracts;
using Payment.Domain.Entities;
using ServiceBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.EventConsumer
{
    public class CheckoutEventConsumer : IConsumer<CheckoutEvent>
    {
        private readonly IBillRepo _repo;
        private readonly IMapper _mapper;

        public CheckoutEventConsumer(IBillRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CheckoutEvent> context)
        {
            var bill = _mapper.Map<Bill>(context.Message);
            await _repo.Add(bill);
        }
    }
}
