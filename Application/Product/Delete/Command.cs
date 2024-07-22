using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Product;
//Delete

public partial class DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public class Handler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {

            var product = await _dbContext.Products.FindAsync(request.Id, cancellationToken) ??
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found."));

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteProductResponse
            {
                Success = true,
                Message = "product deleted successfully"
            };


        }
    }
}
