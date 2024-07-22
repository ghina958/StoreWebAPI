using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Product;
//GetAll
public partial class ListProductsRequest : IRequest<ListProductsResponse>
{
    public class Handler : IRequestHandler<ListProductsRequest, ListProductsResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListProductsResponse> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.Include(c => c.Store)
               .Where(x => request.Name == null || x.Name.Contains(request.Name))
               .Where(x => request.Price == null || x.Price == request.Price.Value)
               .Where(a => request.StoreId == null || a.StoreId == request.StoreId.Value)
               .ToListAsync();
            return new ListProductsResponse()
            {

                Product = { _mapper.Map<List<GetProductByIdResponse>>(product) }
            };



        }


    }
}
