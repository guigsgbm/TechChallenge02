﻿using Microsoft.AspNetCore.Mvc;
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
}
