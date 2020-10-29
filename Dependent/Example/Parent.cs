using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dependent.Example
{
    public class Parent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Child> Children { get; set; }

        public class ParentTypeConfiguration : IEntityTypeConfiguration<Parent>
        {
            public void Configure(EntityTypeBuilder<Parent> builder)
            {
                builder.ToTable(
                    "Parent",
                    DependentContext.Schema,
                    tableBuilder => tableBuilder.ExcludeFromMigrations());

                builder.OwnsMany(o => o.Children, b =>
                {
                    b.ToTable("Children", DependentContext.Schema, true);
                });
            }
        }
    }

    public class Child
    {
        public Guid Id { get; set; }
        public string ChildName { get; set; }
    }
}