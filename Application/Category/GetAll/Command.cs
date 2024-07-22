using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Application.Category;
//GetAll
public partial class ListCategoriesRequest : IRequest<ListCategoriesResponse>
{
    public class Handler : IRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
    {
        private readonly StoreWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(StoreWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListCategoriesResponse> Handle(ListCategoriesRequest request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories
               .Where(x => request.Name == null || x.Name.Contains(request.Name)).ToListAsync();
            return new ListCategoriesResponse()
            {

                Category = { _mapper.Map<List<NewCategoryResponse>>(category) }
            };



        }


    }
}