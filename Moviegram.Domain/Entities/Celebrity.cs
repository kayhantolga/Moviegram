using System;
using System.Collections.Generic;

namespace Moviegram.Domain.Entities
{
    public class Celebrity
    {
        public Celebrity()
        {
            Movies = new HashSet<MovieCelebrity>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }

        public virtual IEnumerable<MovieCelebrity> Movies { get; set; }

    }
}