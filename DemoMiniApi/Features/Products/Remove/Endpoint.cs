namespace DemoMiniApi.Features.Products.Remove;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUnitOfWork uow, CancellationToken ct)
    {
        var product = await uow.Products.FindAsync(req.Id, ct);

        if (product == null)
        {
            return Results.NotFound(req.Id);
        }

        await uow.Products.DeleteAsync(product, ct);
        await uow.SaveChangesAsync(ct);

        return Results.NoContent();
    }
}
