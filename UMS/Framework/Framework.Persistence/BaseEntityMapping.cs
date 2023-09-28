using Framework.Core.Persistence;
using Framework.Domain;
using Framework.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
namespace Framework.Persistence;

public abstract class BaseEntityMapping<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityMapping where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnType(nameof(SqlDbType.UniqueIdentifier))
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(c => c.Timestamp)
            .HasColumnType(nameof(SqlDbType.DateTime))
            .IsRequired();

        builder.HasKey(c => c.Id);

        OnConfigure(builder);

        ToTable(builder);
    }

    public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);

    private static void ToTable(EntityTypeBuilder<TEntity> builder)
    {
        var entityType = typeof(TEntity);

        var tableName = entityType.Name;
        var schemaName = entityType.Namespace?.Split('.')[0];
        builder.ToTable(tableName.ToPlural(), schemaName);
    }


}