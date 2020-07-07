﻿using Core.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Core
{
    public class DbMainContext : ApiAuthorizationDbContext<Account>
    {
        public DbMainContext(DbContextOptions<DbMainContext> options, IOptions<OperationalStoreOptions> opts) : base(options, opts)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(c => c.Comments);
            modelBuilder.Entity<Account>().HasMany(c => c.Likes);
            modelBuilder.Entity<Account>().HasOne(c => c.CreatedBy);
            modelBuilder.Entity<Account>().HasOne(c => c.ModifiedBy);

            modelBuilder.Entity<Film>().HasMany(x => x.Likes);
            modelBuilder.Entity<Film>().HasMany(x => x.FilmsGenres);
            modelBuilder.Entity<Film>().HasMany(x => x.Likes);
            modelBuilder.Entity<Film>().HasOne(c => c.CreatedBy);
            modelBuilder.Entity<Film>().HasOne(c => c.ModifiedBy);

            modelBuilder.Entity<Genre>();

            modelBuilder.Entity<Like>().HasOne(x => x.Owner);
            modelBuilder.Entity<Like>().HasOne(x => x.Film);

            modelBuilder.Entity<Comment>().HasOne(x => x.Film);
            modelBuilder.Entity<Comment>().HasOne(x => x.Owner);
            modelBuilder.Entity<Comment>().HasOne(c => c.CreatedBy);
            modelBuilder.Entity<Comment>().HasOne(c => c.ModifiedBy);

            modelBuilder.Entity<FilmGenre>().HasOne(x => x.Film);
            modelBuilder.Entity<FilmGenre>().HasOne(x => x.Genre);


            base.OnModelCreating(modelBuilder);
        }

    }
}
