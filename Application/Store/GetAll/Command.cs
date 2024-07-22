using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Store;
//GetAll

public partial class GetAllStoresRequest : IRequest<GetAllStoresResponse>
{
    public class Handler : IRequestHandler<GetAllStoresRequest, GetAllStoresResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetAllStoresResponse> Handle(GetAllStoresRequest request, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores
               .Where(x => request.Name == null || x.Name.Contains(request.Name))
               .Where(x => request.CategoryId == null || x.CategoryId==request.CategoryId.Value)
               .ToListAsync();
            return new GetAllStoresResponse()
            {

                Store = { _mapper.Map<List<GetByIdStoreResponse>>(store) }
            };



        }


    }
}