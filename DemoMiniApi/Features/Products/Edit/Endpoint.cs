namespace DemoMiniApi.Features.Products.Edit;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Parameters param, IValidator<Request> validator, IUnitOfWork uow, IMapper mapper, CancellationToken ct)
    {
        validator.ValidateAndThrow(param.Request);

        var product = await uow.Products.FindAsync(param.Id, ct);

        if (product == null)
        {
            return Results.NotFound(param.Id);
        }

        mapper.Map(param.Request, product);

        await uow.Products.UpdateAsync(product, ct);
        await uow.SaveChangesAsync(ct);

        return Results.NoContent();
    }
}
