﻿using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI
{
    public class NoticiaDBContext : DbContext
    {
        public NoticiaDBContext(DbContextOptions optiones) : base(optiones)
        {

        }

        public DbSet<Noticia> Noticia {get; set;}
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloCreador)
        {
            new Noticia.Mapeo(modeloCreador.Entity<Noticia>());
            new Autor.Mapeo(modeloCreador.Entity<Autor>());
        }

    }
}
