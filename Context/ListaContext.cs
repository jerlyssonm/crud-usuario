using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webApi.Entities;

namespace webApi.Context
{
    public class ListaContext : DbContext
    {
        public ListaContext(DbContextOptions<ListaContext> options) : base(options)
        {}
        public DbSet<Usuario> Usuarios{get; set;}
    }

}