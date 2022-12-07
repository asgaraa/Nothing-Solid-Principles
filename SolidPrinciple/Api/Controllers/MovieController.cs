using Api.Data;
using Api.DTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Http;
using System.Reflection;

namespace Api.Controllers
{
   
    public class MovieController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(AppDbContext context, IMapper mapper)
        {
             _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateMovie")]
        public async Task<IActionResult> Create([FromBody] MovieDto movieDto)
        {
            bool isExist = _context.Movies.Any(m => m.Title.ToLower().Trim() == movieDto.Title.ToLower().Trim());

            if (isExist)
            {

                return BadRequest();
            }

            var model =  _mapper.Map<Movie>(movieDto);
            await _context.Movies.AddAsync(model);
            await _context.SaveChangesAsync();

         
            return Ok();
        }

        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<IActionResult> Update([FromBody] MovieEditDto movieEditDto)
        {
            var model = _mapper.Map<Movie>(movieEditDto);
            if (model is null) throw new ArgumentNullException();

            _context.Update(model);

            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Movie> GetById([FromRoute] int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is null) throw new NullReferenceException();

            return movie;
           
        }

        [HttpDelete]
        [Route("DeleteBanner/{id}")]
    
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model =await GetById(id);

            if (model is null) throw new ArgumentNullException();

            _context.Remove(model);
        
            await _context.SaveChangesAsync();
            return Ok();
        }
      
    }
}
