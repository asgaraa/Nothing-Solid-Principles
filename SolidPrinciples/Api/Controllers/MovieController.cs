using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Movie;
using ServiceLayer.Services.Interfaces;
using System.Data;

namespace Api.Controllers
{
   
    public class MovieController : BaseController
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateMovie")]    
        public async Task<IActionResult> Create([FromBody] MovieDto movieDto)
        {
            await _service.CreateAsync(movieDto);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteMovie/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<IActionResult> Update([FromBody] MovieEditDto movieEditDto)
        {
            await _service.UpdateAsync(movieEditDto.Id, movieEditDto);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

    }
}
