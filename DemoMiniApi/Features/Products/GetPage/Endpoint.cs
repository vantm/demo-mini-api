namespace DemoMiniApi.Features.Products.GetPage;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUnitOfWork uow, IMapper mapper, IValidator<Request> validator)
    {
        validator.ValidateAndThrow(req);

        var page = await uow.Products.SelectPageAsync(pageParams: req);
        var responseItems = mapper.Map<ResponseItem[]>(page.Items);
        var response = new Response();

        response.SetParams(req);
        response.SetResult(responseItems, page.Total);

        return Results.Ok(response);
    }
}
