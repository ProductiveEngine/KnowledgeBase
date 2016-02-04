using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class CategoryAccessor
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly CategoryRepo _repo;

        public CategoryAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repo = new CategoryRepo(_uow);
        }

        public CategoryRepo Repo
        {
            get { return _repo; }
        }

        public void Save()
        {
            _uow.Save();
        }
    }
}
