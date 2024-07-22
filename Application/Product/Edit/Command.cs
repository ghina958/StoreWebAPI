using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Product;
//Edit

public partial class EditProductRequest : IRequest<GetNewProductResponse>
{
    public class Handler : IRequestHandler<EditProductRequest, GetNewProductResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetNewProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores.FirstOrDefaultAsync(m => m.Id == request.StoreId) ??

                   throw new RpcException(new Status(StatusCode.NotFound, "Store not found."));

            var exitingProduct = await _dbContext.Products.FirstOrDefaultAsync(s => s.Id == request.Id) ??

                throw new RpcException(new Status(StatusCode.Cancelled, "Product not found!"));

                    var product = _mapper.Map<Domain.Product>(request);
                    await _dbContext.AddAsync(product, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<GetNewProductResponse>(product);


        }


    }
}