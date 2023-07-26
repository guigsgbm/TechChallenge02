using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace WebApp.Pages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Notice Notice { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Notices == null)
        {
            return NotFound();
        }

        var notice = await _context.Notices.FirstOrDefaultAsync(m => m.Id == id);

        if (notice == null)
        {
            return NotFound();
        }
        else
        {
            Notice = notice;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Notices == null)
        {
            return NotFound();
        }
        var notice = await _context.Notices.FindAsync(id);

        if (notice != null)
        {
            Notice = notice;
            _context.Notices.Remove(Notice);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
