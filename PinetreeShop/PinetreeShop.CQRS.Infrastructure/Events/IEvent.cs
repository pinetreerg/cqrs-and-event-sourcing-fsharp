﻿using System;

namespace PinetreeShop.CQRS.Infrastructure.Events
{
    public interface IEvent
    {
        Guid AggregateId { get; }
        Metadata Metadata { get; }
    }

    public class EventBase : IEvent
    {
        public Guid AggregateId { get; set; }
        public Metadata Metadata { get; set; }

        public EventBase(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Metadata = new Metadata();
        }
    }

    public class EventFailedBase : EventBase
    {
        public static string UnknownError = "UnknownError";        
        public string Reason { get; set; }

        public EventFailedBase(Guid aggregateId, string reason) : base(aggregateId)
        {
            Reason = reason;
        }
    }

    public class Metadata
    {
        public Guid EventId { get; private set; }
        public Guid CausationId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime Date { get; private set; }

        public Metadata()
        {
            EventId = Guid.NewGuid();
            Date = DateTime.Now;
        }
    }
}