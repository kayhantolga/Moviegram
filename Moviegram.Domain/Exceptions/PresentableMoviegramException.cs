using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Domain.Exceptions
{
    public class PresentableMoviegramException
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string UserFriendlyMessage { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
