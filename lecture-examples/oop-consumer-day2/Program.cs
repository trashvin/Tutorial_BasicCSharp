using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_sample_day2;
using oop_sample_day2.abstracts;


namespace oop_consumer_day2
{
    class Program
    {
        static void Main(string[] args)
        {

            BaseMusicPlayer basePlayer = new BaseMusicPlayer();
            basePlayer.Stop();

            MP3Player mp3Player = new MP3Player();
            mp3Player.Stop();

            Console.WriteLine("-----------------------");

     

            MusicFile popSong = new MusicFile("pop song");
            popSong.Title = "Poppy Music";
            popSong.Artist = "Yahoo Singers";
            popSong.Album = "No Title";

            SongSamplers sampler = new SongSamplers("sampler");
            sampler.Title = "Rock It";
            sampler.Album = "We Bounce";
            sampler.Artist = "Yeye Band";

            Console.WriteLine("-----------------------");

            basePlayer.Play(popSong);
            mp3Player.Play(sampler);

            List<ASoundFiles> songs = new List<ASoundFiles>
            {
                popSong,
                sampler,
                popSong,
                popSong
            };

            TestPlayer(mp3Player, songs);

            Console.ReadLine();
        }

        static void TestPlayer(AMusicPlayer player, List<ASoundFiles> songs)
        {

            foreach(var song in songs)
            {
                player.Play(song);
            }

            player.Stop();
        }
    }
}
