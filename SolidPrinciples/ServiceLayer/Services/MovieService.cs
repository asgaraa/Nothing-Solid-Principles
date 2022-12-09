using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Movie;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(MovieDto movieDto)
        {
            var model = _mapper.Map<Movie>(movieDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var studentdetail = await _repository.GetAsync(id);
            await _repository.DeleteAsync(studentdetail);
        }

        public async Task<List<MovieDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<MovieDto>>(model);
            return res;
        }

        public async Task<MovieDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<MovieDto>(model);
            return res;
        }

      

        public async Task UpdateAsync(int Id, MovieEditDto movieEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            _mapper.Map(movieEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
