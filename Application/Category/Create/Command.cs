using AutoMapper;
using DataAccess;
using MediatR;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Category;

public partial class NewCategoryRequest : IRequest<NewCategoryResponse>
{
    public class Handler : IRequestHandler<NewCategoryRequest, NewCategoryResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewCategoryResponse> Handle(NewCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Category>(request);
            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<NewCategoryResponse>(category);
        }
    }


}
