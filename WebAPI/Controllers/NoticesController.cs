using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/notices")]
public class NoticesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ApiDbContext _context;

    public NoticesController(IMapper mapper, ApiDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UploadNotice([FromBody] CreateNoticeDto noticeDto)
    {
        if (ModelState.IsValid)
        {
            var notice = _mapper.Map<Notice>(noticeDto);

            var result = await _context.Notices.AddAsync(notice);
            _context.SaveChanges();

            return Ok(result.Entity);
        }

        return BadRequest();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotice(int id)
    {
        var notice = _context.Notices.FirstOrDefault(x => x.Id == id);

        if (notice == null)
            return NotFound("Notice not found");

        return Ok(notice);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetNotices()
    {
        var notices = _context.Notices.ToList();

        if (!notices.Any())
            return NotFound("Notices aren't found");

        return Ok(notices);
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotice(int id)
    {
        var notice = _context.Notices.FirstOrDefault(x => x.Id == id);

        if (notice == null)
            return NotFound();

        var result = _context.Notices.Remove(notice);
        await _context.SaveChangesAsync();

        Console.WriteLine($"Delete successfully.");
        return NoContent();
    }
}
