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
    public class IndexModel : PageModel
    {
        private readonly TCastGroupSebraeAPIContext _context;

        public IndexModel(TCastGroupSebraeAPIContext context)
        {
            _context = context;
        }

        public IList<Conta> Conta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Conta != null)
            {
                Conta = await _context.Conta.ToListAsync();
            }
        }
    }
}
