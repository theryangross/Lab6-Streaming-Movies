using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab_6_Streaming_Movies
{
    public class studioContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        public DbSet<Studio> Studio {get; set;}
        public DbSet<Movie> Movies {get; set;}
    }

    public class Studio
    {
        public int StudioID {get; set;}
        public string StudioName {get; set;}
        public List<Movie> Movies {get; set;} //Nav Prop

        public override string ToString()
        {
            return $"Studio : {StudioID} - {StudioName}";
        }
    }

    public class Movie
    {
        public int MovieID {get; set;}
        public string Title {get; set;}
        public string Genre {get; set;}
        public string StudioID {get; set;} //FK
        public Studio Studio {get; set;}

         public override string ToString()
        {
            return $"Movie {MovieID} : {Title} - {Genre}";
        }
    }
}