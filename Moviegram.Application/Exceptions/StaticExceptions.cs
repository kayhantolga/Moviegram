using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moviegram.Domain.Exceptions;

namespace Moviegram.Application.Exceptions
{
    public static partial class StaticExceptions
    {
        private static Dictionary<string, MoviegramException> MoviegramExceptions { get; set; }

        public static Task Init()
        {
            MoviegramExceptions = new Dictionary<string, MoviegramException>();
            MoviegramExceptions.Add("2X0001", new MoviegramException()
            {
                Code = $"2X0001",
                DeveloperMessage = "Hey Developer! Something Wrong.",
                UserFriendlyMessage = "Something Wrong"
            });

            MoviegramExceptions.Add("2X0002", new MoviegramException()
            {
                Code = $"2X0002",
                DeveloperMessage = "Couldn't find any object with given Id.",
                UserFriendlyMessage = "Sorry but we couldn't find."
            });


            return Task.CompletedTask;
        }

        private static MoviegramException E(string e)
        {
            var temp = MoviegramExceptions.GetValueOrDefault(e) ?? MoviegramExceptions.GetValueOrDefault("1X0001");
            return temp;
        }
        public static class AppServerErrors
        {
            private static readonly string BaseCode = "2";
            public static readonly MoviegramException SomeThingWrong = E($"{BaseCode}X0001");
            public static readonly MoviegramException ObjectNotFound = E($"{BaseCode}X0002");


        }
    }
}
