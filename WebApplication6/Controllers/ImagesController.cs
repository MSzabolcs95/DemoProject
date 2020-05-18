using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Images.Queries;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using EFDataAccesLibrary.Application.Images.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository _imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<List<ImageInfo>> Get(string name, DateTime startDate, DateTime endDate)
        {
            return await GetImageListQueryHandler.GetImagesList(_imageRepository, name, startDate, endDate);
        }

        // GET api/<controller>/5



        // POST api/<controller>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task Post([FromBody]List<Base64Image> images)
        {
            foreach (var image in images)
            {
                await UploadImageCommandHandler.UploadImage(_imageRepository, image);
            }
        }

        [HttpGet("download/{id}")]
        public async Task<string> Download(int id)
        {
            return await DownloadImageCommandHandler.DownloadImage(_imageRepository, id);
        }
        // PUT api/<controller>/5
        [HttpPost("delete")]
        public async Task Delete([FromBody]int id)
        {
             await DeleteImageCommandHandler.DeleteImage(_imageRepository, id);
        }
        [HttpPost("rename")]
        public async Task Rename(string newFileName)
        {
            await RenameImagesCommandHandler.RenameImages(_imageRepository, newFileName);
        }

        [HttpGet("filterByName")]
        public async Task<List<ImageInfo>> FilterByName(string name)
        {
            return await GetImagesFilteredByNameQueryHandler.GetImagesFilteredByName(_imageRepository, name);
        }

        [HttpGet("filterByDate")]
        public async Task<List<ImageInfo>> FilterByDateRange (DateTime startDate, DateTime endDate)
        {
            return await GetImagesFilteredByDateRangeQueryHandler.GetImagesFilteredByDateRange(_imageRepository, startDate, endDate);
        }
    }
}
