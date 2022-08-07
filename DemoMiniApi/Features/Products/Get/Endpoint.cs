namespace DemoMiniApi.Features.Products.Get;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUnitOfWork uow, IMapper mapper, CancellationToken ct)
    {
        var product = await uow.Products.FindAsync(req.Id, ct);

        if (product == null)
        {
            return Results.NotFound(req.Id);
        }

        var response = mapper.Map<Response>(product);

        return Results.Ok(response);
    }
}
