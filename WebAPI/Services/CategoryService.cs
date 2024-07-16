using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Category;
using StoreWebAPI.WebAPI.Services;

namespace StoreWebAPI.Services;
internal class CategoryService : Categories.CategoriesBase
{
    private readonly IMediator _mediator;

    public CategoryService(IMediator mediator)
    {
        _mediator = mediator;
    }
    //public override async Task<CategoryData> Create(NewCategoryRequest request, ServerCallContext context)
    //{
    //    return await _mediator.Send(request);
    //}


}
