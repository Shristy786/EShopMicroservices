
using CatalogAPI.Products.LocalStorage;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

        public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command object

            //save to database 

            //return CreateProductResult result

            var product = new Product
            {

                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Imagefile = command.ImageFile,
                Price = command.Price
            };

            //commented these lines as docker desktop not working and PostgreSql not connected

            //session.Store(product);
            //await session.SaveChangesAsync(cancellationToken);
            //return new CreateProductResult(Guid.NewGuid());

            //added line for local storage and to verify minimal Api
            LocalProductStore.Products.Add(product);
            return new CreateProductResult(Guid.NewGuid()); 
          
        }
    }
}
