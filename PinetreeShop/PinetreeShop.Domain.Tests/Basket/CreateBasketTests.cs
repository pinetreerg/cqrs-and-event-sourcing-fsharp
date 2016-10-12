﻿using PinetreeShop.Domain.Baskets.Commands;
using PinetreeShop.Domain.Baskets.Events;
using PinetreeShop.Domain.Exceptions;
using System;
using Xunit;

namespace PinetreeShop.Domain.Tests.Basket
{
    public class CreateBasketTests : AggregateTestBase
    {
        Guid id = Guid.NewGuid();
        Guid causationAndCorrelationId = Guid.NewGuid();

        [Fact]
        public void When_CreateBasket_BasketCreated()
        {
            var command = new CreateBasket(id);
            command.Metadata.CausationId = command.Metadata.CommandId;
            command.Metadata.CorrelationId = causationAndCorrelationId;

            When(command);

            var expectedEvent = new BasketCreated(id);
            expectedEvent.Metadata.CausationId = command.Metadata.CommandId;
            expectedEvent.Metadata.CorrelationId = causationAndCorrelationId;

            Then(expectedEvent);
        }


        [Fact]
        public void When_CreateBasketWithSameGuid_ThrowAggregateExistsException()
        {
            Given(new BasketCreated(id));
            WhenThrows<AggregateExistsException>(new CreateBasket(id));
        }

    }
}