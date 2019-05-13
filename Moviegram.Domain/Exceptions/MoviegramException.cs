using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviegram.Domain.Exceptions
{
    [Serializable]
    public class MoviegramException : Exception
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string UserFriendlyMessage { get; set; }
        public string DeveloperMessage { get; set; }


        public MoviegramException(string errorMessage)
        {
            DeveloperMessage = errorMessage;
        }

        public MoviegramException()
        {
        }

        public MoviegramException(IEnumerable<string> resultErrors)
        {
            DeveloperMessage = resultErrors.FirstOrDefault();
        }

        public PresentableMoviegramException ToPresentable()
        {
            var temp = new PresentableMoviegramException()
            {
                Id = Id,
                Code = Code,
                DeveloperMessage = DeveloperMessage,
                UserFriendlyMessage = UserFriendlyMessage,
            };
            return temp;
        }

    }
}
