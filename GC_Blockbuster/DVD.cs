using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Blockbuster
{
    class DVD : Movie
    {
        public DVD(string Title, string Genre, int Runtime, List<string> Scenes) : base(Title, Genre, Runtime, Scenes) { }
        public void Play(string input)
        {
            //Simply displays all scenes
            if (input == "1")
            {
                Console.WriteLine("\nPlaying Movie...");
                for (int i = 0; i < Scenes.Count; i++)
                {
                    Console.WriteLine(Scenes[i]);
                }
            }
            else
            {
                //DVD Scene Selection menu
                while (true)
                {
                    bool valid = false;
                    int j = 0;

                    //Print Scenes for selection
                    Console.WriteLine();
                    Console.WriteLine("\n::SCENE LIST::");
                    for (int i = 0; i < Scenes.Count; i++)
                    {
                        Console.WriteLine(Scenes[i]);
                    }
                    Console.WriteLine("\n7) EXIT");
                    Console.Write("\nPlease choose a scene: ");

                    //Getting input and validating
                    string startPoint = Console.ReadLine();
                    switch (startPoint)
                    {
                        case "1":
                            j = 0;
                            valid = true;
                            break;
                        case "2":
                            j = 1;
                            valid = true;
                            break;
                        case "3":
                            j = 2;
                            valid = true;
                            break;
                        case "4":
                            j = 3;
                            valid = true;
                            break;
                        case "5":
                            j = 4;
                            valid = true;
                            break;
                        case "6":
                            j = 5;
                            valid = true;
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("\n~INVALID INPUT: Choose a number from the list~");
                            break;
                    }
                    //If selection was valid, will set index to user selection and display appropriate scenes
                    if (valid)
                    {
                        Console.WriteLine("\nPlaying movie...");
                        for (int i = j; i < Scenes.Count; i++)
                        {
                            Console.WriteLine(Scenes[i]);
                        }

                    }

                }
            }

        }
    }
}
