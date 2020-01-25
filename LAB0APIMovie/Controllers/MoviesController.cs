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


                var data3 = data.TakeLast(10).ToList();
                return data3;
            }


        }

        // GET: api/Movies/id
        [HttpGet("{Id}")]
        public async Task<ActionResult<Movie>> GetMovie(string id)
        {
            var movie = await _context.movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/id
       
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutMovie(string id, Movie movie)
        {
            if (id != movie.Nombre)
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
                if (!MovieExists(id))
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
                if (MovieExists(movie.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovie", new {Id = movie.Id }, movie);
        }

        // DELETE: api/Movies/Id
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(string id)
        {
            var movie = await _context.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(string id)
        {
            return _context.movies.Any(e => e.Id == id);
        }
    }
}
