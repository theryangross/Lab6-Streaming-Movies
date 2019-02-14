using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab_6_Streaming_Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new studioContext())
            {
                // Deleting database
                db.Database.EnsureDeleted();
                // Creating database
                db.Database.EnsureCreated();
            }

            // Adding studios
            using (var db = new studioContext())
            {
                Studio CentryFox = new Studio
                {  
                    StudioName = "20th Century Fox",
                    // Adding movies
                    Movies = new List<Movie>
                    {
                        new Movie { Title = "Avatar", Genre = "Action"},
                        new Movie { Title = "Deadpool", Genre = "Action"},
                        new Movie { Title = "Apollo 13", Genre = "Drama"},
                        new Movie { Title = "The Matrian", Genre = "Sci-Fi"}
                    }
                };

                // Adding second studio
                Studio UniversalPictures = new Studio
                {
                    StudioName = "Universal Pictures"
                };

                db.Add(CentryFox);
                db.Add(UniversalPictures);
                db.SaveChanges();
            }

            // Adding movie to database
            using (var db = new studioContext())
            {
                Movie Movies = new Movie { Title = "Jurassic Park", Genre = "Action"};
                Studio updateStudio = db.Studio.Include(m => m.Movies).Where(m => m.StudioName == "Universal Pictures").First();
                updateStudio.Movies.Add(Movies);
                db.SaveChanges();
            }            

            // Movie movie to different studio
            using (var db = new studioContext())
            {
                Movie Movies = db.Movies.Where(s => s.Title == "Apollo 13").First();
                Movies.Studio = db.Studio.Where(s => s.StudioName == "Universal Pictures").First();
                db.SaveChanges();
            }

            // Removing Movie
            using (var db = new studioContext())
            {
                Movie Movies = db.Movies.Where(s => s.Title == "Deadpool").First();
                db.Remove(Movies);
                db.SaveChanges();
            }

            // Listing movies
            using (var db = new studioContext())
            {
                var studio = db.Studio.Include(s => s.Movies);
                foreach (var s in studio)
                {
                    Console.WriteLine(s);
                    foreach (var m in s.Movies)
                    {
                        Console.WriteLine("\t" + m);
                    }
                }
            }
        }
    }
}
