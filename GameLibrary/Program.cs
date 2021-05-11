using System;
using System.Linq;
using GameLibrary.Entities;
using GameLibrary.Enums;


namespace GameLibrary
{
    
    class Program
    {
        private static GameRepository repository = new GameRepository();
        
        static void Main(string[] args)
        {
            var option = GetUserOption();
            
            while (option != "0")
            {
                switch (option)
                {
                    case "1":
                        ListGames();
                        break;
                    case "2":
                        InsertGame();
                        break;
                    case "3":
                        UpdateGame();
                        break;
                    case "4":
                        DeleteGame();
                        break;
                    case "5":
                        ShowDetails();
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            
                option = GetUserOption();
            
            }
        }

        private static int ValidateIdInput()
        {
            bool result;
            int id;

            do
            {
                Console.WriteLine("Insert the games` Id");
                var input = Console.ReadLine();
                result = int.TryParse(input, out id);

                if (!result)
                {
                    Console.WriteLine("Invalid Id.");
                }
                
            } while (!result);

            return id;
        }

        private static int ValidateGenreInput()
        {
            bool result;
            int id;
            do
            {
                Console.WriteLine($"Select the genre from the options above: ");
                var input = Console.ReadLine();
                result = int.TryParse(input, out id);

                if (!result || (id > 5 && id < 0))
                {
                    Console.WriteLine("Invalid Id.");
                }
                
            } while (!result);

            return id;
        }

        private static int ValidateYearInput()
        {
            bool result;
            int id;

            do
            {
                Console.WriteLine("Release Year: ");
                var input = Console.ReadLine();
                result = int.TryParse(input, out id);

                if (!result)
                {
                    Console.WriteLine("Invalid Year.");
                }
                
            } while (!result);

            return id;
        }

        private static void ShowDetails()
        {
            var id = ValidateIdInput();

            var game = repository.GetById(id);
            
            Console.WriteLine(game);
        }

        private static void DeleteGame()
        {
            var id = ValidateIdInput();
            
            repository.Delete(id);
        }

        private static void UpdateGame()
        {
            var id = ValidateIdInput();

            var game = FillNewGameInfo(id);
            
            repository.Update(game.Id, game);

        }

        private static void InsertGame()
        {
            repository.Insert(FillNewGameInfo(repository.NextId()));
        }

        private static Game FillNewGameInfo(int id)
        {
            foreach (int index in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", index, Enum.GetName(typeof(Genre), index));
            }
            
            var genreInput = ValidateGenreInput();
            
            Console.WriteLine("Game Title: ");
            var titleInput = Console.ReadLine();
            
            Console.WriteLine("Description: ");
            var descInput = Console.ReadLine();
            
            Console.WriteLine("Release Year: ");
            var yearInput = int.Parse(Console.ReadLine());

            var newGame = new Game(id, (Genre) genreInput, titleInput, descInput, yearInput);

            return newGame;
        }

        private static void ListGames()
        {

            var games = repository.List().Where(game => !game.IsDeleted());

            if (!games.Any())
            {
                Console.WriteLine("There is no game registered.");
                return;
            }
            
            foreach (var game in games)
            {
                Console.WriteLine("#ID {0}: - {1}", game.GetId(), game.GetTitle());
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Game Library!!!");
            Console.WriteLine("Select a option:");

            Console.WriteLine("1- Show games");
            Console.WriteLine("2- Insert new game");
            Console.WriteLine("3- Update game");
            Console.WriteLine("4- Delete game");
            Console.WriteLine("5- See game details");
            Console.WriteLine("0- Exit");
            Console.WriteLine();

            var op = Console.ReadLine();
            Console.WriteLine();
            return op;
            
        }
    }
}