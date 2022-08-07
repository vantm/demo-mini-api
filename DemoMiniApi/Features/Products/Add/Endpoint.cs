using DemoMiniApi.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Products.Add;

public static class Endpoint
{
    public static async Task<IResult> Handle([FromBody] Request req, IValidator<Request> validator, IUnitOfWork uow, IMapper mapper, LinkGenerator linker, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var product = mapper.Map<Product>(req);

        await uow.Products.InsertAsync(product, ct);

        var uri = linker.GetPathByName("GetProduct", new { id = product.Id });
        var response = mapper.Map<Response>(product);

        await uow.SaveChangesAsync(ct);

        if (uri == null)
        {
            return Results.Json(response, statusCode: StatusCodes.Status201Created);
        }

        return Results.Created(uri, response);
    }
}
