using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        private readonly IProductRepository _productRepository;

        public ProductMutation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    }
}
