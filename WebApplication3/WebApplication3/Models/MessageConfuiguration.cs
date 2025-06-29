//-
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebApplication3.Models;

public class MessageConfuiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Mesages").HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}
