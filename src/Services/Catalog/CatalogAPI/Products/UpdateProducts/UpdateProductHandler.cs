
using FluentValidation;

namespace CatalogAPI.Products.UpdateProducts
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool ISsucess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is Required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required")
                .Length(2, 6);

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be gretaer than 0");


        }
    }

        internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
            : ICommandHandler<UpdateProductCommand, UpdateProductResult>
        {
            public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", command);

                var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

                if (product == null)
                {
                    throw new ProductNotFoundException();
                }

                product.Name = command.Name;
                product.Category = command.Category;
                product.Description = command.Description;
                product.Imagefile = command.ImageFile;
                product.Price = command.Price;

                session.Update(product);
                await session.SaveChangesAsync(cancellationToken);

                return new UpdateProductResult(true);


            }
        }
    
}
