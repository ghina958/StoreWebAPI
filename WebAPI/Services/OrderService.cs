using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Order;
using StoreWebAPI.Services;

namespace StoreWebAPI.Services;
internal class OrderService : Orders.OrdersBase
{
    private readonly IMediator _mediator;

    public OrderService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<NewOrderResponse> Create(NewOrderRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
}
   
