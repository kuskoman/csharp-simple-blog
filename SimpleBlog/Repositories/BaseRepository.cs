using SimpleBlog.Database;
using SimpleBlog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Repositories
{
    public class BaseRepository<Model> : IBaseRepository<Model> where Model : class, IModel
    {
        protected readonly DbSet<Model> _dbSet;
        protected readonly BlogContext _ctx;

        public BaseRepository(BlogContext ctx, DbSet<Model> dbSet)
        {
            _ctx = ctx;
            _dbSet = dbSet;
        }

        public List<Model> GetAll()
        {
            return _dbSet.ToList();
        }

        public Model? Get(uint id)
        {
            var model = _dbSet.Find(id);
            return model;
        }

        public Model Delete(uint id)
        {
            var dbModel = _dbSet.Find(id);
            if (dbModel == null)
            {
                throw new ArgumentException($"Could not find model with id ${id}");
            }

            _ctx.Remove(dbModel);
            _ctx.SaveChanges();

            return dbModel;
        }

        public Model Create(Model model)
        {
            _dbSet.Add(model);
            _ctx.SaveChanges();
            return model;
        }

        public Model Modify(Model newModel)
        {
            var oldModel = _dbSet.Find(newModel.Id);
            if (oldModel == null)
            {
                throw new ArgumentException("Could not find model with given id");
            }

            _ctx.Entry(oldModel).CurrentValues.SetValues(newModel);
            _ctx.SaveChanges();
            return newModel;
        }
    }
}
