using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace WebApp.Pages;

[Authorize(Roles = "admin")]
public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.News == null)
        {
            return NotFound();
        }
        var news = await _context.News.FindAsync(id);

        if (news != null)
        {
            News = news;
            _context.News.Remove(News);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
