using AutoMapper;
using DataAccess;
using Domain;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Store;

//GetById
public partial class GetByIdStoreRequest : IRequest<GetByIdStoreResponse>
{
    public class Handler : IRequestHandler<GetByIdStoreRequest, GetByIdStoreResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetByIdStoreResponse> Handle(GetByIdStoreRequest request, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??

                   throw new RpcException(new Status(StatusCode.NotFound, "Store not found."));

            return _mapper.Map<GetByIdStoreResponse>(store);
        }

    }
}
