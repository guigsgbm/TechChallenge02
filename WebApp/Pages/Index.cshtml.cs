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

    public IList<News> News { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.News != null)
        {
            News = await _context.News.ToListAsync();
        }
    }
}
