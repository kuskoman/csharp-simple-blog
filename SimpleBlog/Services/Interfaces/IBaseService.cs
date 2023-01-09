namespace SimpleBlog.Services.Interfaces
{
    public interface IBaseService<Model>
    {
        public List<Model> GetAll();
        public Model? Get(uint id);
        public Model Create(Model model);
        public Model Delete(uint id);
        public Model Modify(Model model);
    }
}
