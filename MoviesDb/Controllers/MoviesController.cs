using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{title}/find")]
        public ActionResult GetBy(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            var movie = this._service.FindByParameters(title);
            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet]
        [Route("{title}/{year}/find")]
        public ActionResult GetByA(string title, string year)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            if(string.IsNullOrWhiteSpace(year))
            {
                return BadRequest();
            }

            var movie = this._service.FindByParameters(title, year);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet]
        [Route("{title}/{year}/{genre}/find")]
        public ActionResult GetByA(string title, string year, string genre)
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

            var movie = this._service.FindByParameters(title, year, genre);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
