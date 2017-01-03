﻿module PinetreeShop.Domain.Orders.Tests.Create

open PinetreeShop.Domain.Tests.TestBase
open PinetreeShop.Domain.Orders.OrderAggregate
open PinetreeShop.Domain.Orders.Tests.Base
open PinetreeCQRS.Infrastructure.Commands
open PinetreeCQRS.Infrastructure.Events
open PinetreeCQRS.Infrastructure.Types
open Xunit
open System

let aggregateId = Guid.NewGuid() |> AggregateId
let basketId = Guid.NewGuid() |> BasketId

[<Fact>]
let ``When Create OrderCreated`` () = 
    let command = Create(basketId, ShippingAddress "Address") |> createCommand aggregateId (Expected(0), None, None, None)
    let expected = OrderCreated(basketId, ShippingAddress "Address") |> createExpectedEvent command 1
    handleCommand [] command |> checkSuccess expected

[<Fact>]
let ``When Create without shippingAddress`` () = 
    Create(basketId, ShippingAddress "")
    |> createCommand aggregateId (Expected(0), None, None, None)
    |> handleCommand []
    |> checkFailure [ ValidationError "Shipping Address cannot be empty" ]

[<Fact>]
let ``When Create created fail`` () = 
    let initialEvent = OrderCreated(basketId, ShippingAddress "a") |> createInitialEvent aggregateId 1
    Create(basketId, ShippingAddress "a")
    |> createCommand aggregateId (Irrelevant, None, None, None)
    |> handleCommand [ initialEvent ]
    |> checkFailure [ ValidationError "Order already created" ]