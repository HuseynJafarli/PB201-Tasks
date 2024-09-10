﻿using API_INTRO.DAL;
using API_INTRO.DTOs.GenreDTOs;
using API_INTRO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_INTRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public GenresController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _appDbContext.Genres.ToListAsync();

            List<GenreGetDto> genreGetDtos = data.Select(x => new GenreGetDto(x.Id, x.Name)).ToList();

            return Ok(genreGetDtos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id < 1) return BadRequest();
            var data = await _appDbContext.Genres.FindAsync(id);
            if (data is null) return NotFound();

            GenreGetDto genreGetDto = new(data.Id, data.Name);

            return Ok(genreGetDto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] GenreCreateDto genreCreateDto)
        {
            if (genreCreateDto is null) return BadRequest();

            Genre genre = new()
            {
                Name = genreCreateDto.name,
                IsDeleted = false,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _appDbContext.Genres.AddRangeAsync(genre);
            await _appDbContext.SaveChangesAsync();

            return Created(new Uri($"/api/genres/{genre.Id}", UriKind.Relative), genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GenreUpdateDto genreUpdateDto)
        {
            if (id < 1) return BadRequest();
            if (genreUpdateDto is null) return BadRequest();

            var data = await _appDbContext.Genres.FindAsync(id);

            if (data is null) return NotFound();

            data.ModifiedDate = DateTime.Now;
            data.Name = genreUpdateDto.name;
            await _appDbContext.SaveChangesAsync();


            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id < 1) return BadRequest();

            var data = await _appDbContext.Genres.FindAsync(id);

            if (data is null) return NotFound();

            _appDbContext.Genres.Remove(data);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

