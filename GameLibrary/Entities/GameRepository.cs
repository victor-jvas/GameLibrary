using System.Collections.Generic;
using GameLibrary.Interfaces;

namespace GameLibrary.Entities
{
    public class GameRepository: IRepository<Game>
    {
        private List<Game> GameList = new List<Game>();
        
        public List<Game> List()
        {
            return GameList;
        }

        public void Insert(Game game)
        {
            GameList.Add(game);
        }

        public void Delete(int id)
        {
            GameList[id].Delete();
        }

        public void Update(int id, Game game)
        {
            GameList[id] = game;
        }

        public int NextId()
        {
            return GameList.Count;
        }

        public Game GetById(int id)
        {
            return GameList[id];
        }
    }
}