using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Blockbuster
{
    class VHS : Movie
    {
        public int CurrentTime { get; set; } = 0;
        public VHS(string Title, string Genre, int Runtime, List<string> Scenes) : base(Title, Genre, Runtime, Scenes) { }
        public void Play()
        {
            //Validates currentTime is within range and plays if valid
            if (CurrentTime < Scenes.Count)
            {
                for (int i = CurrentTime; i < Scenes.Count; i++)
                {
                    Console.WriteLine(Scenes[i]);
                    CurrentTime++;
                }
            }
            else
            {
                Console.WriteLine("\n~Please rewind the tape to play~");
            }
        }
        public void Rewind()
        {
            CurrentTime = 0;
        }
    }
}
