using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Settings;
using Microsoft.Extensions.Configuration;
using Business.Abstract;

namespace Business.Concrete
{
    public class MusicAddManager :IMusicSettings
    {
        private readonly IConfiguration _configuration;
        private Cloudinary _cloudinary;
        private MusicSettings _pictureSetting;

        public MusicAddManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _pictureSetting = configuration.GetSection("CloudInarySettings")
            .Get<MusicSettings>();

            Account account = new Account(_pictureSetting.Name, _pictureSetting.ApiKey, _pictureSetting.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public string AddMusic(IFormFile? formFile)
        {
            var stream = formFile.OpenReadStream();

            var uploadParams = new AutoUploadParams()
            {
                File = new FileDescription(formFile.Name, stream)
            };
            var result = _cloudinary.Upload(uploadParams);
            if (result.Uri.ToString() != null)
            {
                return result.Uri.ToString();
            }
            return "";
        }
    }
}
