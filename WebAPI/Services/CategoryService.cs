using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Category;
using StoreWebAPI.Services;

namespace StoreWebAPI.Services;
internal class CategoryService : Categories.CategoriesBase
{
    private readonly IMediator _mediator;

    public CategoryService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<NewCategoryResponse> Create(NewCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<NewCategoryResponse> Edit(EditCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<NewCategoryResponse> GetById(getCategoryDataByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<DeleteCategoryResponse> Delete(DeleteCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<ListCategoriesResponse> ListAll(ListCategoriesRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

}
