namespace DemoMiniApi.Common
{
    public interface IUow
    {
        void Begin();
        void Complete();
        void Rollback();
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
