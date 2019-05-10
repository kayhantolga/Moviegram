using System;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    public class MovieShowTimeResponseModel
    {
        public MovieShowTimeResponseModel(MovieShowTimeViewModel model)
        {
            if (model == null) return;

            EndTime = model.EndTime;
            StartTime = model.StartTime;
        }

        /// <summary>
        ///     Start time of movie. Ignore date, use only Time section
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     End time of movie. Ignore date, use only Time section
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}