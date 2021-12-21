using BarberShop.Bll.DTOs;
using BarberShop.Bll.Helpers;
using BarberShop.Web.Enums;
using BarberShop.Web.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BarberShop.Web.Services
{
    public class FileOperationService : IFileOperationService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly long _maxFileSize;
        private readonly List<string> _allowedExtensions;

        public FileOperationService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _maxFileSize = configuration.GetValue<long>("MaxFileSize");
            _allowedExtensions = configuration.GetSection("AllowedExtensions").Get<List<string>>();
        }

        public async Task<(string, FileErrorType?)> SaveFileAsync(BarberDTO barber)
        {
            var fileName = barber.Photo.FileName;

            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !_allowedExtensions.Contains(ext))
            {
                return (null, FileErrorType.NotAllowedExtension);
            }

            if (barber.Photo.Length > _maxFileSize)
            {
                return (null, FileErrorType.Size);
            }

            var photoPath = $"barberImages/{barber.Name.ToLower()}{DateTime.Now}".RemoveStrings(new string[] { " ", ".", "-", ":" }).RemoveAccents();
            photoPath = $"{photoPath}{ext}";

            var filePath = Path.Combine(_environment.WebRootPath, photoPath);

            using (var stream = System.IO.File.Create(filePath))
            {
                await barber.Photo.CopyToAsync(stream);
            }

            return (photoPath, null);
        }
    }
}