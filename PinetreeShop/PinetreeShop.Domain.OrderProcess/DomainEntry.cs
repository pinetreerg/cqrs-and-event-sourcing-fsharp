﻿using PinetreeShop.CQRS.Infrastructure.Commands;
using PinetreeShop.CQRS.Infrastructure.Events;
using PinetreeShop.CQRS.Infrastructure.Repositories;
using PinetreeShop.CQRS.Infrastructure;
using System;

namespace PinetreeShop.Domain.OrderProcess
{
    public class DomainEntry
    {
        public static void InitializeEventHandler(IProcessEventHandler eventHandler)
        {
            eventHandler.RegisterHandler(EventHandlers.BasketCheckedOut);
            eventHandler.RegisterHandler(EventHandlers.ProductReserved);
            eventHandler.RegisterHandler(EventHandlers.ProductReservationFailed);
            eventHandler.RegisterHandler(EventHandlers.OrderCreated);
            eventHandler.RegisterHandler(EventHandlers.OrderCancelled);
            eventHandler.RegisterHandler(EventHandlers.CreateOrderFailed);
            eventHandler.RegisterHandler(EventHandlers.OrderDelivered);
            eventHandler.RegisterHandler(EventHandlers.OrderShipped);
        }        
    }
}