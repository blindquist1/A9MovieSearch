using ApplicationTemplate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

/// <summary>
///     Class to handle file read and display
/// </summary>

namespace ApplicationTemplate.Context
{
    public class MediaContext
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }
        
        string _file;
        //int _id;
        //string _title;

        public MediaContext()
        {
        }

        //Read in the Movies file and add it to the list
        public void MoviesRead()
        {
            _file = $"{Environment.CurrentDirectory}/data/movies.json";
            Movies = new List<Movie>();

            using (StreamReader sr = new StreamReader(_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Movie m = JsonConvert.DeserializeObject<Movie>(line);
                    Movies.Add(new Movie() { Id = m.Id, Title = m.Title, Genres = m.Genres });
                }
                // close file when done
                sr.Close();
            };
        }

        //Display the Movies list
        public void MoviesDisplay()
        {
            foreach (Movie movie in Movies)
            {
                movie.Display();
            }
        }

        //Read in the Shows file
        public void ShowsRead()
        {
            _file = $"{Environment.CurrentDirectory}/data/shows.json";
            Shows = new List<Show>();

            using (StreamReader sr = new StreamReader(_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Show s = JsonConvert.DeserializeObject<Show>(line);
                    Shows.Add(new Show() { Id = s.Id, Title = s.Title, Season = s.Season, Episode = s.Episode, Writers = s.Writers });
                }
                // close file when done
                sr.Close();
            };
        }

        //Display the Shows list
        public void ShowsDisplay()
        {
            foreach (Show show in Shows)
            {
                show.Display();
            }
        }

        //Read in the Videos file
        public void VideosRead()
        {
            _file = $"{Environment.CurrentDirectory}/data/videos.json";
            Videos = new List<Video>();

            using (StreamReader sr = new StreamReader(_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Video v = JsonConvert.DeserializeObject<Video>(line);
                    Videos.Add(new Video() { Id = v.Id, Title = v.Title, Length = v.Length, Regions = v.Regions, Formats = v.Formats });
                }
                // close file when done
                sr.Close();
            };
        }
        
        //Display the videos list
        public void VideosDisplay()
        {
            foreach (Video video in Videos)
            {
                video.Display();
            }
        }
    }
}
