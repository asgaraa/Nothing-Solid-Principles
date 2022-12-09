using ServiceLayer.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IMovieService
    {
        Task CreateAsync(MovieDto movieDto);

        Task UpdateAsync(int Id, MovieEditDto movieEditDto);
        Task DeleteAsync(int id);
        Task<List<MovieDto>> GetAllAsync();
        Task<MovieDto> GetAsync(int id);
    }
}
