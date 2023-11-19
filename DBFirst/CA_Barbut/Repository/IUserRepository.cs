using CA_Barbut.Models;

namespace CA_Barbut.Repository
{
    public interface IUserRepository
    {
        public User GetByName(string userName);
        public string GetById(int id);
        public bool Validate(string userName, string password);
    }
}
