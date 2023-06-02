using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCastGroupSebrae.API.Model;

    public class TCastGroupSebraeAPIContext : DbContext
    {
        public TCastGroupSebraeAPIContext (DbContextOptions<TCastGroupSebraeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TCastGroupSebrae.API.Model.ViaCep> ViaCep { get; set; } = default!;

        public DbSet<TCastGroupSebrae.API.Model.Conta> Conta { get; set; }
    }
