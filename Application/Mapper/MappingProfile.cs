using AutoMapper;
using Domain;
using StoreWebAPI.Application.Category;
using StoreWebAPI.Application.Order;
using StoreWebAPI.Application.Product;
using StoreWebAPI.Application.Store;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() {

        #region product
        CreateMap<NewProductRequest, Domain.Product>();
        CreateMap<Product, GetNewProductResponse>(); //reponse of Create,Edit

        CreateMap<EditProductRequest, Domain.Product>();

        CreateMap<GetProductByIdRequest, Product>();
        CreateMap<Product, GetProductByIdResponse>();

        CreateMap<Product, DeleteProductRequest>();
        CreateMap<DeleteProductResponse, Product>();

        CreateMap<Product, ListProductsRequest>();
        CreateMap<ListProductsResponse, Product>();
        #endregion

        #region category

        CreateMap<NewCategoryRequest, Domain.Category>();
        CreateMap<Category, NewCategoryResponse>();//reponse of Create,Edit,getById

        CreateMap<EditCategoryRequest, Category>();

        CreateMap<getCategoryDataByIdRequest, Category>();

        CreateMap<DeleteCategoryRequest, Category>();
        CreateMap<Category, DeleteCategoryResponse>();

        CreateMap<ListCategoriesRequest, Category>();
        CreateMap<Category, ListCategoriesResponse>();

        #endregion


        #region order

        CreateMap<NewOrderRequest, Domain.Order>();
        CreateMap<Order, NewOrderResponse>();

        CreateMap<EditOrderRequest, Domain.Order>();

        CreateMap<GetOrderByIdRequest, Domain.Order>();

        #endregion

        #region store

        CreateMap<NewStoreRequest, Domain.TheStore.Store>();
        CreateMap<Domain.TheStore.Store, NewStoreResponse>();

        CreateMap<GetByIdStoreRequest, Domain.TheStore.Store>();
        CreateMap<Domain.TheStore.Store, GetByIdStoreResponse>();

        CreateMap<EditStoreRequest, Domain.TheStore.Store>();

        CreateMap<DeleteStoreRequest, Domain.TheStore.Store>();
        CreateMap<Domain.TheStore.Store, DeleteStoreResponse>();

        CreateMap<GetAllStoresRequest, Domain.TheStore.Store>();
        CreateMap<EditStoreRequest, GetAllStoresResponse>();

        #endregion


    }
}
