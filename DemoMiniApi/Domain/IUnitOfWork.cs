using DemoMiniApi.Domain.Products;
using DemoMiniApi.Domain.Users;

namespace DemoMiniApi.Domain
{
    public interface IUnitOfWork
    {
        void Begin();
        void Complete();
        void Rollback();
        IProductRepository Products { get; }
        IUserRepository Users { get; set; }
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
