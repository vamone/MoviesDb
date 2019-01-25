using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesDb.Services;

namespace MoviesDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("{title}/find")]
        public ActionResult FindByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            try
            {
                var movie = this._service.FindByParameters(title);
                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                //TODO: LOGG
                throw new Exception("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{title}/{year}/find")]
        public ActionResult FindByTitleAndYear(string title, string year)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(year))
            {
                return BadRequest();
            }

            try
            {
                var movie = this._service.FindByParameters(title, year);
                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                //TODO: LOGG
                throw new Exception("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{title}/{year}/{genre}/find")]
        public ActionResult FindByTitleYearAndGenre(string title, string year, string genre)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(year))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest();
            }

            try
            {
                var movie = this._service.FindByParameters(title, year, genre);
                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                //TODO: LOGG
                throw new Exception("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{itemsCount}/top")]
        public ActionResult FindTopFiveMovies(int itemsCount)
        {
            if(itemsCount < 0)
            {
                return BadRequest();
            }

            try
            {
                var movies = this._service.GetTopMovies(itemsCount);
                if(movies == null)
                {
                    return NotFound();
                }

                if(!movies.Any())
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                //TODO: LOGG
                throw new Exception("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{itemsCount}/{userId}/top")]
        public ActionResult FindTopFiveMoviesByUserId(int itemsCount, string userId)
        {
            if (itemsCount < 0)
            {
                return BadRequest();
            }

            if(string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            try
            {
                var movies = this._service.GetTopMovies(itemsCount, userId);
                if (movies == null)
                {
                    return NotFound();
                }

                if (!movies.Any())
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                //TODO: LOGG
                throw new Exception("Internal Server Error");
            }
        }
    }
}
