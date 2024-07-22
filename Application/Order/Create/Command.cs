using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Order;
//Create
public partial class NewOrderRequest : IRequest<NewOrderResponse>
{
    public class Handler : IRequestHandler<NewOrderRequest, NewOrderResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NewOrderResponse> Handle(NewOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Users.FirstOrDefaultAsync(m => m.Id == request.CustomerId) ??

                  throw new RpcException(new Status(StatusCode.NotFound, "customer not found."));

            var order = _mapper.Map<Domain.Order>(request);
            await _dbContext.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<NewOrderResponse>(order);


        }


    }
}
