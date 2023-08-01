using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace WebApp.Pages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public News News { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.News == null)
        {
            return NotFound();
        }

        var news = await _context.News.FirstOrDefaultAsync(m => m.Id == id);
        if (news == null)
        {
            return NotFound();
        }
        else
        {
            News = news;
        }
        return Page();
    }
}
