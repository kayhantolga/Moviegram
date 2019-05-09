using System;
using System.Linq.Expressions;
using Moviegram.Domain.Entities;

namespace Moviegram.Application.Models.ViewModels
{
    public class MovieShowTimeViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public static Expression<Func<MovieShowTime, MovieShowTimeViewModel>> Projection
        {
            get
            {
                return item => new MovieShowTimeViewModel
                {
                    EndTime = item.ShowTimeEnd,
                    StartTime = item.ShowTimeStart
                };
            }
        }

        public static MovieShowTimeViewModel FromEntity(MovieShowTime entity)
        {
            return entity == null ? new MovieShowTimeViewModel() : Projection.Compile().Invoke(entity);
        }
    }
}