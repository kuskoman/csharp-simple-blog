namespace SimpleBlog.Repositories.Interfaces
{
    public interface IBaseRepository<Model>
    {
        public List<Model> GetAll();
        public Model? Get(uint id);
        public Model Create(Model model);
        public Model Delete(uint id);
        public Model Modify(Model model);
    }
}
