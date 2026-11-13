
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            Song song1 = new Song();
            song1.SetName("Rosalia");
            song1.SetAuthor("T-Fest");
            song1.SetPrev(null);

            Song song2 = new Song();
            song2.SetName("back to friend");
            song2.SetAuthor("sombr");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("Back Home");
            song3.SetAuthor("Yeat");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Царица");
            song4.SetAuthor("ANNA ASTI");
            song4.SetPrev(song3);

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);

            Console.WriteLine("Список песен:");

            foreach (Song song in songs)
            {
                song.Print();
            }

            Console.WriteLine();

            Console.WriteLine("Сравнение первой и второй песни:");

            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Песни одинаковые");
            }
            else
            {
                Console.WriteLine("Песни разные");
            }
        }
    }

    class Song
    {
        string name;
        string author;
        Song prev;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public void Print()
        {
            Console.WriteLine(Title());
        }

        public string Title()
        {
            return name + " - " + author;
        }

        public override bool Equals(object d)
        {
            if (d == null || !(d is Song))
            {
                return false;
            }

            Song other = (Song)d;

            return name == other.name && author == other.author;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }
    }
}
