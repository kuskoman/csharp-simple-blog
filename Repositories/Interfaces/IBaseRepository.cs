namespace SimpleBlog.Repositories.Interfaces
{
    public interface IBaseRepository<Model>
    {
        public List<Model> GetAll();
        public Model? Get(int id);
        public Model Create(Model model);
        public Model Delete(int id);
        public Model Modify(Model model);
    }
}
