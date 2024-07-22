using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Category;
//GetById
public partial class getCategoryDataByIdRequest : IRequest<NewCategoryResponse>
{
    public class Handler : IRequestHandler<getCategoryDataByIdRequest, NewCategoryResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewCategoryResponse> Handle(getCategoryDataByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??

                   throw new RpcException(new Status(StatusCode.NotFound, "Category not found."));

            return _mapper.Map<NewCategoryResponse>(category);
        }


    }
}
