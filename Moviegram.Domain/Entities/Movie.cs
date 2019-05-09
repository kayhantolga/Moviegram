using System;
using System.Collections.Generic;

namespace Moviegram.Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
            Actors = new HashSet<MovieCelebrity>();
            MovieShowTimes = new HashSet<MovieShowTime>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }
        public virtual ICollection<MovieShowTime> MovieShowTimes { get; set; }

        //For showing Relational Database skills
        public virtual ICollection<MovieCelebrity> Actors { get; set; }
    }
}