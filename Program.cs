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
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            using (var db = new studioContext())
            {
                Studio CentryFox = new Studio
                {  
                    StudioName = "20th Century Fox",
                    Movies = new List<Movie>
                    {
                        new Movie { Title = "Avatar", Genre = "Action"},
                        new Movie { Title = "Deadpool", Genre = "Action"},
                        new Movie { Title = "Apollo 13", Genre = "Drama"},
                        new Movie { Title = "The Matrian", Genre = "Sci-Fi"}
                    }
                };

                Studio UniversalPictures = new Studio
                {
                    StudioName = "Universal Pictures"
                };
            }

            using (var db = new studioContext())
            {
                Movie Movies = new Movie { Title = "Jurassic Park", Genre = "Action"};
                Studio studioToUpdate = db.Studio.Include(s => s.Movies).Where(s => s.)
            }            

            using (var db = new studioContext())
            {

            }
        }
    }
}
