using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Notice> Notice { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Notices != null)
        {
            Notice = await _context.Notices.ToListAsync();
        }
    }
}
