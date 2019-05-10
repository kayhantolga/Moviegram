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

        /// <summary>
        ///     Id of Celebrity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Full name of celebrity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Profile photo of celebrity
        /// </summary>
        public string ProfilePhoto { get; set; }
    }
}