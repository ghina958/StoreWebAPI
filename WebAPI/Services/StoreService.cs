using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Store;

namespace StoreWebAPI.Services;
internal class StoreService : Stores.StoresBase
{
    private readonly IMediator _mediator;

    public StoreService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<NewStoreResponse> Create(NewStoreRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetByIdStoreResponse> GetById(GetByIdStoreRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<NewStoreResponse> Edit(EditStoreRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetAllStoresResponse> GetAll(GetAllStoresRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<DeleteStoreResponse> Delete(DeleteStoreRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
}
