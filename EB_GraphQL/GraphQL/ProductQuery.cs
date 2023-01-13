using Domain;
using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> Products()
        {
            return _productRepository.Products;
        }
    }
}
