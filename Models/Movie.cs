using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     Class to handle properties and Display method for a single Movie
/// </summary>

namespace ApplicationTemplate.Models
{
    public class Movie : Media //Uses the abstract class Media
    {
        //These are properties
        public string[] Genres { get; set; }

        public override void Display() //Will override Display() in Media
        {
            System.Console.WriteLine($"Title: {Title} Genres: {string.Join(", ", Genres)}");
        }
    }
}