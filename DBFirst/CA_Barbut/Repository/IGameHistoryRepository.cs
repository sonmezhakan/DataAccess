using CA_Barbut.Models;

namespace CA_Barbut.Repository
{
    public interface IGameHistoryRepository
    {
        public List<GameHistory> GetList();
        public void Add(GameHistory gameList);
    }
}
