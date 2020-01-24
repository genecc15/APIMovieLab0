using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB0APIMovie.Models;
using System.IO;

namespace LAB0APIMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Getmovies()
        {

            if (_context.movies == null)
            {

                var data3 = _context.movies.ToListAsync();
                return await data3;
            }
            else
            {
                var data = _context.movies.ToList();


                var data3 = data.TakeLast(3).ToList();
                return data3;
            }


        }

        // GET: api/Movies/nombre
        [HttpGet("{Nombre}")]
        public async Task<ActionResult<Movie>> GetMovie(string nombre)
        {
            var movie = await _context.movies.FindAsync(nombre);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/nombre
       
        [HttpPut("{Nombre}")]
        public async Task<IActionResult> PutMovie(string nombre, Movie movie)
        {
            if (nombre != movie.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(nombre))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
      
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.movies.Add(movie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovie", new { Nombre = movie.Nombre }, movie);
        }

        // DELETE: api/Movies/nombre
        [HttpDelete("{Nombre}")]
        public async Task<ActionResult<Movie>> DeleteMovie(string nombre)
        {
            var movie = await _context.movies.FindAsync(nombre);
            if (movie == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(string nombre)
        {
            return _context.movies.Any(e => e.Nombre == nombre);
        }
    }
}
