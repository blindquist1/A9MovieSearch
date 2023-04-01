using A5Movie.Services;
using ApplicationTemplate.Context;
using ApplicationTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace ApplicationTemplate.Services;

/// <summary>
///     Main program to run the user interface. Inherits from IMainService.
/// </summary>
public class MainService : IMainService
{
    public MainService()
    {

    }
    
    public void Invoke()
    {
        int menuSelection = 0;
        //Max number of menu options. Allows programmer to change in one spot if menu item added or removed.
        int maxMenu = 5;

        while (menuSelection != maxMenu)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. List Movies");
            Console.WriteLine("2. List Shows");
            Console.WriteLine("3. List Videos");
            Console.WriteLine("4. Search Media");
            Console.WriteLine("5. Exit");
            Console.WriteLine();

            bool validEntry = false;

            //Keep looping through until user chooses a valid entry, an integer and between 1 and the maxMenu option.
            while (!validEntry)
            {
                menuSelection = InputService.GetIntWithPrompt("Select an option: ", "Entry must be an integer");
                if (menuSelection < 1 || menuSelection > maxMenu)
                {
                    Console.WriteLine($"Entry must be between 1 and {maxMenu}");
                }
                else
                {
                    validEntry = true;
                }
            }

            MediaContext context = new MediaContext();

            if (menuSelection == 1)
            {
                context.MoviesRead();
                context.MoviesDisplay();

            }
            else if (menuSelection == 2)
            {
                context.ShowsRead();
                context.ShowsDisplay();
            }
            else if (menuSelection == 3)
            {
                context.VideosRead();
                context.VideosDisplay();
            }

            else if (menuSelection == 4)
            {
                //Read in all the media
                context.MoviesRead();
                context.ShowsRead();
                context.VideosRead();

                Console.WriteLine("What title are you looking for?");
                var searchString = Console.ReadLine();

                //Using LINQ Where here to find the search criteria
                var resultsMovies = context.Movies.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                var resultsShows = context.Shows.Where(s => s.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                var resultsVideos = context.Videos.Where(v => v.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));

                //Total number of media found with the search criteria entered by the user
                var resultCount = resultsMovies.Count() + resultsShows.Count() + resultsVideos.Count();
                
                //Using LINQ Count here to total the number of media entries in all the files
                var mediaCount = context.Movies.Count() + context.Shows.Count() + context.Videos.Count();

                //Display each movie found with the search criteria
                foreach (var movie in resultsMovies)
                {
                    Console.WriteLine($"Movie: {movie.Title}");
                }
                //Display each show found with the search criteria
                foreach (var show in resultsShows)
                {
                    Console.WriteLine($"Show: {show.Title}");
                }
                //Display each video found with the search criteria
                foreach (var video in resultsVideos)
                {
                    Console.WriteLine($"Video: {video.Title}");
                }

                //Display the number of matches found out of the total number of media entries in all files
                Console.WriteLine();
                Console.WriteLine($"Found {resultCount} matches out of {mediaCount} total media entries.");
            }

            if (menuSelection != maxMenu)
            {
                Console.WriteLine();
            }
        }
    }
}
