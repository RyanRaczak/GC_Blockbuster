using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Blockbuster
{
    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Runtime { get; set; }
        public List<string> Scenes { get; set; } = new List<string>();
        public Movie(string Title, string Genre, int Runtime, List<string> Scenes)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Runtime = Runtime;
            this.Scenes = Scenes;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("\n{0,-25}{1,-13}{2,-5}", "Title", "Genre", "Runtime");
            Console.WriteLine("=================================================");
            Console.WriteLine($"{Title,-25}{Genre,-13}{Runtime,-8}");
        }
        public override string ToString()
        {
            return $"{Title,-25}{Genre,-13}{Runtime,-8}";
        }
    }
}
