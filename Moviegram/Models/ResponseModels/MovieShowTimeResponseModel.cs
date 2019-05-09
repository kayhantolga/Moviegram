using System;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    public class MovieShowTimeResponseModel
    {
        public MovieShowTimeResponseModel(MovieShowTimeViewModel model)
        {
            EndTime = model.EndTime;
            StartTime = model.StartTime;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}