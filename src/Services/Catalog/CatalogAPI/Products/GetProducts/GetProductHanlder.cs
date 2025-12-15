
using CatalogAPI.Models;
using CatalogAPI.Products.LocalStorage;

namespace CatalogAPI.Products.GetProduct
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductQueryHanlder(IDocumentSession session)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
          

            //commented these lines as docker desktop not working and PostgreSql not connected
            //var products=await session.Query<Product>().ToListAsync(cancellationToken);

            //added line for local storage and to verify minimal Api
            var products = LocalProductStore.Products;

            return new GetProductsResult(products);
        }
    }
}
