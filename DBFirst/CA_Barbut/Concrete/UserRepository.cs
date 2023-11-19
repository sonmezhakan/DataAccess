using CA_Barbut.Models;
using CA_Barbut.Repository;

namespace CA_Barbut.Concrete
{
    public class UserRepository : IUserRepository
    {
        BarbutGameDbContext context = new BarbutGameDbContext();

        public string GetById(int id)
        {
            return context.Users.Find(id).UserName;
        }

        public User GetByName(string userName)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public bool Validate(string userName, string password)
        {
            //Any metotu koleksiyonun içerisinde en az bir bilginin bulunup bulunmadığını kontrol eder. Eğer en az bir bilgi var ise true, yoksa false döner. Yani yapılan sorgulamada sonuç bulunamasa false bulunursa true döner.
            return context.Users.Any(x => x.UserName == userName && x.Password == password);
        }
    }
}
