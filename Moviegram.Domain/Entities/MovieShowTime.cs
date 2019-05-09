using System;

namespace Moviegram.Domain.Entities
{
    public class MovieShowTime
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime ShowTimeStart { get; set; }
        public DateTime ShowTimeEnd { get; set; }
    }
}