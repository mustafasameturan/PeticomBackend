using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class SubCommentConfiguration : IEntityTypeConfiguration<SubComment>
{
    public void Configure(EntityTypeBuilder<SubComment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.CommentId).IsRequired();
        builder.Property(p => p.Text).IsRequired().HasMaxLength(500);
        builder.Property(p => p.LikeCount).IsRequired();
        builder.HasOne(p => p.Comment).WithMany(p => p.SubComments).HasForeignKey(p => p.CommentId);
    }
}