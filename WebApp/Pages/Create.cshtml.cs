using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages;

[Authorize]
public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public News News { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.News == null || News == null)
        {
            return Page();
        }

        _context.News.Add(News);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
