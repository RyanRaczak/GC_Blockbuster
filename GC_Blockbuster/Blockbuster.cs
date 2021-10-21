using System;
using System.Collections.Generic;

namespace GC_Blockbuster
{
    class Blockbuster
    {
        //public List<Movie> Movies = new List<Movie>(); //Can't call child methods with list of parents.
        List<VHS> vhsMovies = new List<VHS>();
        List<DVD> dvdMovies = new List<DVD>();
        public Blockbuster()
        {
            List<string> scenes = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                scenes.Add($"Scene: {i + 1} shh i'm very creative.");
            }
            dvdMovies.Add(new DVD("Big Hero 6", "Drama", 120, scenes));
            dvdMovies.Add(new DVD("Happy Gilmore", "Comedy", 80, scenes));
            dvdMovies.Add(new DVD("The Strangers", "Horror", 100, scenes));
            vhsMovies.Add(new VHS("Toy Story", "Romance", 125, scenes));
            vhsMovies.Add(new VHS("Toy Soldiers", "Action", 75, scenes));
            vhsMovies.Add(new VHS("Little Mermaid", "Animated", 120, scenes));

            //Movies.Add(new DVD("Big Hero 6", "Drama", 120, scenes));
            //Movies.Add(new DVD("Happy Gilmore", "Comedy", 80, scenes));
            //Movies.Add(new DVD("The Strangers", "Horror", 100, scenes));
            //Movies.Add(new VHS("Toy Story", "Romance", 125, scenes));
            //Movies.Add(new VHS("Toy Soldiers", "Action", 75, scenes));
            //Movies.Add(new VHS("Little Mermaid", "Animated", 120, scenes));
        }
        public void PrintMovies()
        {
            //Prints both VHS and DVD list
            Console.WriteLine("\n   {0,-25}{1,-13}{2,-5}", "Title", "Genre", "Runtime");
            Console.WriteLine("=================================================");
            for (int i = 0; i < dvdMovies.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {dvdMovies[i]}");
            }
            for (int i = 0; i < vhsMovies.Count; i++)
            {
                Console.WriteLine($"{i + 4}) {vhsMovies[i]}");
            }
        }
        public void CheckOut()
        {
            //Loop to get valid input from user for movie selection
            while (true)
            {
                PrintMovies();
                string input = GetInput("\nPlease select a number from the list: ");
                try
                {
                    int selection = int.Parse(input);
                    //Validates if the selection is in range
                    if (selection >= 1 && selection <= vhsMovies.Count + dvdMovies.Count)
                    {
                        //Determines if selection is in DVD list
                        if (selection >= 1 && selection <= dvdMovies.Count)
                        {
                            Console.WriteLine("\n::MOVIE SELECTED::");
                            dvdMovies[selection - 1].PrintInfo();
                            PlayMenu(selection);
                            return;
                            //return dvdMovies[selection - 1];  
                        }
                        //Determines if selection is in VHS list
                        else if (selection > dvdMovies.Count && selection <= vhsMovies.Count + dvdMovies.Count)
                        {
                            Console.WriteLine("\n::MOVIE SELECTED::");
                            vhsMovies[selection - (dvdMovies.Count +1)].PrintInfo();
                            PlayMenu(selection);
                            return;
                            //return vhsMovies[selection - (dvdMovies.Count + 1)];
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n~INVALID INPUT: Please enter a number from the list~");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n~INVALID INPUT: Please enter a number~");
                    continue;
                }
            }
        }
        public void MainMenu()
        {
            //Gets user input and calls appropriate method
            while (true)
            {
                string input = GetInput("\n::MENU::" +
                    "\n1) Choose Movie" +
                    "\n2) Only List Movie" +
                    "\n3) Exit" +
                    "\n:: ");
                switch (input)
                {
                    case "1":
                        CheckOut();
                        break;
                    case "2":
                        PrintMovies();
                        break;
                    case "3":
                        Console.WriteLine("\n::GOODBYE::");
                        return;
                    default:
                        Console.WriteLine("\n~INVALID INPUT: Enter a number from the list~");
                        break;
                }
            }
        }
        public void PlayMenu(int selection)
        {
            //DVD Options
            if (selection >= 0 && selection <= dvdMovies.Count)
            {
                while (true)
                {
                    string input = GetInput("\n::MENU::" +
                    "\n1) Play Movie" +
                    "\n2) Choose Scene" +
                    "\n3) Exit" +
                    "\n:: ");
                    switch (input)
                    {
                        case "1": //Play Movie
                            dvdMovies[selection - 1].Play(input);
                            break;
                        case "2": //Choose scene
                            dvdMovies[selection - 1].Play(input);
                            break;
                        case "3": //Exit
                            return;
                        default:
                            Console.WriteLine("\n~INVALID INPUT: Enter a number from the list~");
                            break;
                    }
                }  
            }

            //VHS Options
            else if (selection > dvdMovies.Count && selection <= vhsMovies.Count + dvdMovies.Count)
            {
                while (true)
                {
                    string input = GetInput("\n::MENU::" +
                    "\n1) Play Movie" +
                    "\n2) Rewind" +
                    "\n3) Exit" +
                    "\n:: ");
                    switch (input)
                    {
                        case "1": //Play Movie
                            vhsMovies[selection - 4].Play();
                            break;
                        case "2": //Rewind
                            vhsMovies[selection - 4].Rewind();
                            break;
                        case "3": //Exit
                            return;
                        default:
                            Console.WriteLine("\n~INVALID INPUT: Enter a number from the list~");
                            break;
                    }
                }
            }
        }
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
