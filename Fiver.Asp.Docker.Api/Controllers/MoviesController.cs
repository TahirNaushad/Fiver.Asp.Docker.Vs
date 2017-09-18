using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Fiver.Asp.Docker.Api.Models.Movies;
using Fiver.Asp.Docker.Data;
using Fiver.Asp.Docker.Data.Entities;

namespace Fiver.Asp.Docker.Api.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly Database context;

        public MoviesController(Database context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var outputModel = from movie in context.Movies
                              select new
                              {
                                  movie.Id,
                                  movie.Title,
                                  movie.ReleaseYear,
                                  movie.Summary
                              };

            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetItem(int id)
        {
            var outputModel = (from movie in this.context.Movies
                               where movie.Id == id
                               select new
                               {
                                   movie.Id,
                                   movie.Title,
                                   movie.ReleaseYear,
                                   movie.Summary,
                               }).FirstOrDefault();

            if (outputModel == null)
                return NotFound();

            return Ok(outputModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]MovieCreateInputModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            var entity = new Movie
            {
                Title = inputModel.Title,
                ReleaseYear = inputModel.ReleaseYear,
                Summary = inputModel.Summary
            };
            this.context.Movies.Add(entity);
            this.context.SaveChanges();

            var outputModel = new
            {
                entity.Id,
                entity.Title,
                entity.ReleaseYear,
                entity.Summary
            };

            return CreatedAtRoute("GetMovie", new { id = outputModel.Id }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]MovieUpdateInputModel inputModel)
        {
            if (inputModel == null || id != inputModel.Id)
                return BadRequest();

            var entity = new Movie
            {
                Id = inputModel.Id,
                Title = inputModel.Title,
                ReleaseYear = inputModel.ReleaseYear,
                Summary = inputModel.Summary
            };
            this.context.Movies.Update(entity);
            this.context.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = context.Movies
                                .Where(e => e.Id == id)
                                .FirstOrDefault();

            if (entity == null)
                return NotFound();

            this.context.Movies.Remove(entity);
            this.context.SaveChanges();

            return NoContent();
        }
    }
}
