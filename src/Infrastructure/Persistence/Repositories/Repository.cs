using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FlexBook.Domain.Repositories;
using X.PagedList;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly FlexBookDbContext dbContext;

    public Repository(FlexBookDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(TEntity entity, CancellationToken cancellationToken)
    => await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

    public async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    => await dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    => await dbContext.Set<TEntity>().Where(expression).ToListAsync();


     public async Task<bool> IfExist(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    => await dbContext.Set<TEntity>().AnyAsync(expression);

    public async Task<TEntity?> FindById(Guid id, CancellationToken cancellationToken)
        => await dbContext.Set<TEntity>().FindAsync(id, cancellationToken);

    public void Remove(TEntity entity)
        => dbContext.Set<TEntity>().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities)
        => dbContext.Set<TEntity>().RemoveRange(entities);

    public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
   => await dbContext.Set<TEntity>().Where(expression).FirstOrDefaultAsync();



    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      int? skip = null,
      int? take = null,
      string includeProperties = "")
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (filter != null)
            query = query.Where(filter);

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(IncludeProperty);
        }

        if (skip != null && skip.Value > 0)
            query.Skip(skip.Value);

        if (take != null && take.Value > 0)
            query.Take(take.Value);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }




    public async Task<int> CountAsync()
    {
        var query = dbContext.Set<TEntity>().AsNoTracking();
        return await query.CountAsync();
    }
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
    {
        var query = dbContext.Set<TEntity>().AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.CountAsync();
    }
    public async Task<int> CountAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters)
    {
        var query = dbContext.Set<TEntity>().AsNoTracking();

        if (filters != null && filters.Any())
        {
            foreach (var filter in filters)
                query = query.Where(filter);
        }

        return await query.CountAsync();
    }

    public async Task<IPagedList<TEntity>> FindPagedList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageNumber = 1, int pageSize = 10, string includeProperties = "")
    {
        var query = dbContext.Set<TEntity>().AsNoTracking();

        if (filter != null)
            query = query.Where(filter);


        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(IncludeProperty);
        }

        if (orderBy != null)
            query = orderBy(query);

        IPagedList<TEntity> pagedList = default;

        pageNumber = pageNumber < 1 ? 1 : pageNumber;

        pagedList = await query?.ToPagedListAsync(pageNumber, pageSize);

        return pagedList;
    }

    public async Task<IPagedList<TEntity>> FindPagedList(IEnumerable<Expression<Func<TEntity, bool>>> filters = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageNumber = 1, int pageSize = 10, string includeProperties = "")
    {
        var query = dbContext.Set<TEntity>().AsNoTracking();

        if (filters != null && filters.Any())
        {
            foreach (var filter in filters)
                query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(IncludeProperty);
        }

        if (orderBy != null)
            query = orderBy(query);


        IPagedList<TEntity> pagedList = default;

        pageNumber = pageNumber < 1 ? 1 : pageNumber;

        pagedList = await query?.ToPagedListAsync(pageNumber, pageSize);

        return pagedList;
    }
}
