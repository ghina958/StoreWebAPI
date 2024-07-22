using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Product;
using StoreWebAPI.Services;

namespace StoreWebAPI.Services;
internal class ProductService :Products.ProductsBase
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<GetNewProductResponse> Create(NewProductRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<GetNewProductResponse> Edit(EditProductRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<DeleteProductResponse> Delete(DeleteProductRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<GetProductByIdResponse> GetById(GetProductByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<ListProductsResponse> GetAll(ListProductsRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

}
