using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;

namespace StoreWebAPI.Application.Category;
//Delete

public partial class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
{
    public class Handler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {

            var category = await _dbContext.Categories.FindAsync(request.Id, cancellationToken) ??
                throw new RpcException(new Status(StatusCode.NotFound, "category not found."));

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteCategoryResponse
            {
                Success = true,
                Message = "category deleted successfully"
            };


        }
    }
}
