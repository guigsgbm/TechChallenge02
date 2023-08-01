using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Data;
using Shared.Models;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public NewsController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Uploadnews([FromBody] CreateNewsDto newsDto)
    {
        if (ModelState.IsValid)
        {
            var news = _mapper.Map<News>(newsDto);

            var result = await _context.News.AddAsync(news);
            _context.SaveChanges();

            return Ok(result.Entity);
        }

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Getnews(int id)
    {
        var news = _context.News.FirstOrDefault(x => x.Id == id);

        if (news == null)
            return NotFound("News not found");

        return Ok(news);
    }

    [HttpGet]
    public async Task<IActionResult> GetNews()
    {
        var news = _context.News.ToList();

        if (!news.Any())
            return NotFound("News aren't found");

        return Ok(news);
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletenews(int id)
    {
        var news = _context.News.FirstOrDefault(x => x.Id == id);

        if (news == null)
            return NotFound();

        var result = _context.News.Remove(news);
        await _context.SaveChangesAsync();

        Console.WriteLine($"Delete successfully.");
        return NoContent();
    }
}
