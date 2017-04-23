using System;


namespace PuskaricLyricCollections
{

    [Serializable]
    public enum Genre { Pop, Country, HipHop, Rap, RnB, Chill, Latino, Rock, Indie, Jazz, Christian, Soul, Folk, Classical, Metal, KPop, Reggae, Punk, Funk, Blues}

    [Serializable]
    public class SongInfo
    {

        public SongInfo()
        {
            Name = "Enter song name";
            Artist = "Nickleback";
            Genre = Genre.Pop;
            Year = 2016;
            Duration = "0:00";
        }

        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Duration { get; set; }
        public string Lyrics { get; set; }
    
        public override string ToString()
        {
                return this.Name; 
        }

    }
}
