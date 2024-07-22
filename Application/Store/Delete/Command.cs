using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using StoreWebAPI.Application.Product;

namespace StoreWebAPI.Application.Store;

//Delete
public partial class DeleteStoreRequest : IRequest<DeleteStoreResponse>
{
    public class Handler : IRequestHandler<DeleteStoreRequest, DeleteStoreResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteStoreResponse> Handle(DeleteStoreRequest request, CancellationToken cancellationToken)
        {

            var store = await _dbContext.Stores.FindAsync(request.Id, cancellationToken) ??
                throw new RpcException(new Status(StatusCode.NotFound, "store not found."));

            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteStoreResponse
            {
                Success = true,
                Message = "store deleted successfully"
            };


        }
    }
}
