using System;
using GameLibrary.Enums;

namespace GameLibrary.Entities
{
    public class Game : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int ReleaseYear { get; set; }
        private bool Deleted { get; set; }

        public Game(int id, Genre genre, string title, string description, int releaseYear)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            Deleted = false;
        }

        public override string ToString()
        {
            var output = "";

            output += "Title: " + Title + Environment.NewLine;
            output += "Genre: " + Genre + Environment.NewLine;
            output += "Description: " + Description + Environment.NewLine;
            output += "Release Year: " + ReleaseYear + Environment.NewLine;

            return output;
        }

        public void Delete()
        {
            this.Deleted = true;
        }

        public bool IsDeleted()
        {
            return Deleted;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetTitle()
        {
            return Title;
        }
    }
}