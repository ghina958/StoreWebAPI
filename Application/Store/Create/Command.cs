using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Store;

//Create
public partial class NewStoreRequest : IRequest<NewStoreResponse>
{
    public class Handler : IRequestHandler<NewStoreRequest, NewStoreResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NewStoreResponse> Handle(NewStoreRequest request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == request.CategoryId) ??

                  throw new RpcException(new Status(StatusCode.NotFound, "category not found."));

                var store = _mapper.Map<Domain.TheStore.Store>(request);
                await _dbContext.AddAsync(store, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewStoreResponse>(store);

        }


    }
}
