using Business.Abstract;
using Business.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PictureManager : IPictureSettings
    {
        private readonly IConfiguration _configuration;
        private Cloudinary _cloudinary;
        private PictureSetting _pictureSetting;

        public PictureManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _pictureSetting = configuration.GetSection("CloudInarySettings")
            .Get<PictureSetting>();

            Account account = new Account(_pictureSetting.Name, _pictureSetting.ApiKey, _pictureSetting.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public string Add(IFormFile? img)
        {
            var stream = img.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(img.Name, stream)
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
