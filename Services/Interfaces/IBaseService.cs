namespace SimpleBlog.Services.Interfaces
{
    public interface IBaseService<Model>
    {
        public List<Model> GetAll();
        public Model? Get(int id);
        public Model Create(Model model);
        public Model Delete(int id);
        public Model Modify(Model model);
    }
}
