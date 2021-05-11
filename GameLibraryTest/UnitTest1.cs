using System;
using GameLibrary.Entities;
using GameLibrary.Enums;
using Xunit;

namespace GameLibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddGameToRepository_ShouldWork()
        {
            var r = new GameRepository();

            var game = new Game(r.NextId(), Genre.Action, "Fighting Heroes", "A fighting game with heroes", 2020);
            
            r.Insert(game);
            
            Assert.True(r.NextId() == 1);
            Assert.Contains<Game>(game, r.List());
        }

        [Fact]
        public void UpdateGame_ShouldWork()
        {
            var r = new GameRepository();
            var game = new Game(r.NextId(), Genre.Action, "Fighting Heroes", "A fighting game with heroes", 2020);
            r.Insert(game);
            var newGame = new Game(game.Id, Genre.Adventure, "Adventure Heroes", "A Adventure game with heroes", 2010);
            
            r.Update(game.Id, newGame);

            var result = r.GetById(0);
            
            Assert.True(result.GetTitle() == "Adventure Heroes");
        }

        [Fact]
        public void DeleteGame_ShouldWork()
        {
            var r = new GameRepository();
            var game = new Game(r.NextId(), Genre.Action, "Fighting Heroes", "A fighting game with heroes", 2020);
            r.Insert(game);
            
            r.Delete(0);
            
            Assert.True(r.GetById(0).IsDeleted());
        }
    }
}