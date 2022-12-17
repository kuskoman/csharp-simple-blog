using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public abstract class BaseService<Model> : IBaseService<Model>
    {
        protected readonly IBaseRepository<Model> _repository;

        public BaseService(IBaseRepository<Model> repository)
        {
            _repository = repository;
        }

        public List<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public Model? Get(int id)
        {
            return _repository.Get(id);
        }

        public Model Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Model Create(Model post)
        {
            return _repository.Create(post);
        }

        public Model Modify(Model post)
        {
            return _repository.Modify(post);
        }
    }
}
