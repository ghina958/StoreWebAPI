using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Application.Product;

namespace StoreWebAPI.Application.Category;

//Edit
public partial class EditCategoryRequest : IRequest<NewCategoryResponse>
{
    public class Handler : IRequestHandler<EditCategoryRequest, NewCategoryResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewCategoryResponse> Handle(EditCategoryRequest request, CancellationToken cancellationToken)
        {
            var exitingCategory = await _dbContext.Categories.FirstOrDefaultAsync(s => s.Id == request.Id) ??

                throw new RpcException(new Status(StatusCode.Cancelled, "Category not found!"));


                _mapper.Map(request, exitingCategory);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewCategoryResponse>(exitingCategory);


        }


    }
}