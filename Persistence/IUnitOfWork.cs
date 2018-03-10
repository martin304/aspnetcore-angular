using System.Threading.Tasks;

namespace angular2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NgDbContext context;
        public UnitOfWork(NgDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}