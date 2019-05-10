using System;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    public class CelebrityResponseModel
    {
        public CelebrityResponseModel(CelebrityViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            ProfilePhoto = model.ProfilePhoto;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
