using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Data;

namespace WebApp.Pages;

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
    public Notice Notice { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.Notices == null || Notice == null)
        {
            return Page();
        }

        _context.Notices.Add(Notice);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
