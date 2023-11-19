using CA_Barbut.Models;
using CA_Barbut.Repository;
using CA_Barbut.Utils;

namespace CA_Barbut.Concrete
{
    public class GameHistoryRepository : IGameHistoryRepository
    {
        BarbutGameDbContext context = new BarbutGameDbContext();
        public void Add(GameHistory gameHistory)
        {
            context.GameHistories.Add(gameHistory);
            if (context.SaveChanges() == null)
            {
                Messages.GameListAddError();
            }
        }

        public List<GameHistory> GetList()
        {
            return context.GameHistories.ToList();
        }
    }
}
