﻿using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Domain.Comments;
using Havalan.Domain.Posts;
using Havalan.Domain.TrendingNews;
using Havalan.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.Common.Persistence;
public class HavalanDbContext : DbContext, IUnitOfWork
{
    public HavalanDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<TrendingNew> TrendingNews { get; set; }

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HavalanDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}