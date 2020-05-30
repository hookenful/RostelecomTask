using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Repositories;

namespace RostelecomTask.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly AppDbContext Context;

        public Repository(AppDbContext context)
        {
            Context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
