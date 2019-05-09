using System;

namespace Moviegram.Domain.Entities
{
    public class MovieCelebrity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid CelebrityId { get; set; }
        public Celebrity Celebrity { get; set; }
    }
}