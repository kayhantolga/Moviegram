using System;
using System.Linq.Expressions;
using Moviegram.Domain.Entities;

namespace Moviegram.Application.Models.ViewModels
{
    public class CelebrityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public static Expression<Func<Celebrity, CelebrityViewModel>> Projection
        {
            get
            {
                return item => new CelebrityViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ProfilePhoto = item.ProfilePhoto
                };
            }
        }

        public static CelebrityViewModel FromEntity(Celebrity entity)
        {
            return entity == null ? new CelebrityViewModel() : Projection.Compile().Invoke(entity);
        }
    }
}