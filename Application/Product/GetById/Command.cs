using AutoMapper;
using DataAccess;
using Domain;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Product;

//GetById
public partial class GetProductByIdRequest : IRequest<GetProductByIdResponse>
{
    public class Handler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.Include(c => c.Store).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??

                   throw new RpcException(new Status(StatusCode.NotFound, "Product not found."));

             return _mapper.Map<GetProductByIdResponse>(product);
        }


    }
}
