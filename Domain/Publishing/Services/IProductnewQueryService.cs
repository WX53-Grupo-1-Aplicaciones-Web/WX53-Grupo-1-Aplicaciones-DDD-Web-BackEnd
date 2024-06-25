using Domain.Publishing.Models.Queries.ProductQueries;
using Domain.Publishing.Models.Response;

namespace Domain.Publishing.Services;

public interface IProductnewQueryService
{
    Task<List<ProductnewResponse>> Handle(GetAllProductsQuery query);
    Task<ProductnewResponse> Handle(GetProductByIdQuery query);
}