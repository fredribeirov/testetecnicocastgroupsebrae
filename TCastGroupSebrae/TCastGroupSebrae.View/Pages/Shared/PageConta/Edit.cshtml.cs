using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.View.Pages.Shared.PageConta
{
    public class EditModel : PageModel
    {
        private readonly TCastGroupSebraeAPIContext _context;

        public EditModel(TCastGroupSebraeAPIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conta Conta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var conta =  await _context.Conta.FirstOrDefaultAsync(m => m.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            Conta = conta;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Conta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(Conta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContaExists(int id)
        {
          return (_context.Conta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
