//-
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebApplication3.Models;

public class FriendConfiguration : IEntityTypeConfiguration<Friend>
{
    public void Configure(EntityTypeBuilder<Friend> builder)
    {
        builder.ToTable("UserFriends").HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}
