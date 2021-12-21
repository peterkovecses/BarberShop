using BarberShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BarberShop.Data.Entities
{
    public abstract class UserBase : IdentityUser<int>
    {
        public string Name { get; set; }
        public string? PhotoPath { get; set; }
    }

    public abstract class UserBase<TEntity> : UserBase, IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
    }
}
