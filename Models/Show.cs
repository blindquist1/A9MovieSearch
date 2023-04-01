using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     Class to handle properties and Display method for a single Show
/// </summary>

namespace ApplicationTemplate.Models
{
    public class Show : Media //Uses the abstract class Media
    {
        //These are properties special to a Show
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public override void Display() //Will override Display() in Media
        {
            System.Console.WriteLine($"Title: {Title} Season: {Season} Episode: {Episode} Writers: {string.Join(", ", Writers)}");
        }
    }
}
