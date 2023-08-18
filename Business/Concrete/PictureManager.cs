using Business.Abstract;
using Business.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.Results;
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
        private MusicSettings _musicSettings;
        public PictureManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _pictureSetting = configuration.GetSection("CloudInarySettings")
            .Get<PictureSetting>();

            _musicSettings = configuration.GetSection("CloudInarySettings")
                .Get<MusicSettings>();

            Account account = new Account(_pictureSetting.Name, _pictureSetting.ApiKey, _pictureSetting.ApiSecret);
            Account accountMusic = new Account(_musicSettings.Name, _musicSettings.ApiKey, _musicSettings.ApiSecret);

            _cloudinary = new Cloudinary(account);
            _cloudinary = new Cloudinary(accountMusic);

        }
        public async Task<IDataResult<string>> Add(IFormFile? img)
        {
            var stream = img.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(img.Name, stream)
            };
            var result = _cloudinary.Upload(uploadParams);
            if (result.Uri.ToString() != null)
            {
                return new SuccessDataResult<string>(result.Uri.ToString());
            }
            return new ErrorDataResult<string>("");
        }
        public async Task<IDataResult<string>> AddMusic(IFormFile? audio)
        {
            var stream = audio.OpenReadStream();
            var uploadParams = new VideoUploadParams()
            {
                File =new FileDescription(audio.Name, stream)
            };
            var result= _cloudinary.Upload(uploadParams);
            if (result.Uri.ToString() != null)
            {
                return new SuccessDataResult<string>(result.Uri.ToString());
            }
            return new ErrorDataResult<string>("");
        }
    }
}
