using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.View.Pages.Shared.PageConta
{
    public class DeleteModel : PageModel
    {
        private readonly TCastGroupSebraeAPIContext _context;

        public DeleteModel(TCastGroupSebraeAPIContext context)
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

            var conta = await _context.Conta.FirstOrDefaultAsync(m => m.Id == id);

            if (conta == null)
            {
                return NotFound();
            }
            else 
            {
                Conta = conta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }
            var conta = await _context.Conta.FindAsync(id);

            if (conta != null)
            {
                Conta = conta;
                _context.Conta.Remove(Conta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
