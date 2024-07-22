using AutoMapper;
using DataAccess;
using Domain.TheStore;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Store;
//Edit 

public partial class EditStoreRequest : IRequest<NewStoreResponse>
{
    public class Handler : IRequestHandler<EditStoreRequest,NewStoreResponse>
{
    private readonly StoreWebDbContext _dbContext;
    private readonly IMapper _mapper;

    public Handler(StoreWebDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NewStoreResponse> Handle(EditStoreRequest request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == request.CategoryId) ??

              throw new RpcException(new Status(StatusCode.NotFound, "category not found."));

        var store = await _dbContext.Stores.FirstOrDefaultAsync(s => s.Id == request.Id) ??

              throw new RpcException(new Status(StatusCode.Cancelled, "Store not found!"));


            _mapper.Map(request, store);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<NewStoreResponse>(store);

        }
    }
}

