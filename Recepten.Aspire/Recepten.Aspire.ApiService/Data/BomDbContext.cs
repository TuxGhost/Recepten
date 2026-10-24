using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Recepten.Aspire.ApiService.Entities;

namespace Recepten.Aspire.ApiService.Data;

public partial class BomDbContext : DbContext
{
    public BomDbContext(DbContextOptions<BomDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FoodCategory> FoodCategories { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }    

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<SwitchboardItem> SwitchboardItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.FoodCategoryId).HasName("PrimaryKey");

            entity.ToTable("Food Categories");

            entity.Property(e => e.FoodCategoryId)
                .HasAnnotation("Jet:Identity", "($7, $1)")
                .HasAnnotation("Jet:IdentityIncrement", 1)
                .HasAnnotation("Jet:IdentitySeed", 7)
                .HasColumnType("counter")
                .HasColumnName("FoodCategoryID");
            entity.Property(e => e.FoodCategory1)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("FoodCategory");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PrimaryKey");

            entity.Property(e => e.IngredientId)
                .HasAnnotation("Jet:Identity", "($46, $1)")
                .HasAnnotation("Jet:IdentityIncrement", 1)
                .HasAnnotation("Jet:IdentitySeed", 46)
                .HasColumnType("counter")
                .HasColumnName("IngredientID");
            entity.Property(e => e.Ingredient1)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("Ingredient");
        });

       

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PrimaryKey");

            entity.HasIndex(e => e.FoodCategoryId, "FoodCategoryID");

            entity.HasIndex(e => e.RecipeName, "RecipeName");

            entity.Property(e => e.RecipeId)
                .HasAnnotation("Jet:Identity", "($13, $1)")
                .HasAnnotation("Jet:IdentityIncrement", 1)
                .HasAnnotation("Jet:IdentitySeed", 13)
                .HasColumnType("counter")
                .HasColumnName("RecipeID");
            entity.Property(e => e.CaloriesPerServing).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.FoodCategoryId)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("FoodCategoryID");
            entity.Property(e => e.Ingredients).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Instructions).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Notes).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.NumberofServings).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.NutritionalInformation).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.RecipeDescription)
                .HasMaxLength(255)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.TimeToPrepare)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Utensils)
                .HasMaxLength(255)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Vegetarian)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnType("bit");
            entity.Property(e => e.WhichMeal)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)");

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.FoodCategoryId)
                .HasConstraintName("Reference2");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.RecipeIngredientId).HasName("PrimaryKey");

            entity.ToTable("Recipe Ingredients");

            entity.HasIndex(e => e.IngredientId, "IngredientID");

            entity.HasIndex(e => e.RecipeId, "RecipeID");

            entity.Property(e => e.RecipeIngredientId)
                .HasAnnotation("Jet:Identity", "($54, $1)")
                .HasAnnotation("Jet:IdentityIncrement", 1)
                .HasAnnotation("Jet:IdentitySeed", 54)
                .HasColumnType("counter")
                .HasColumnName("RecipeIngredientID");
            entity.Property(e => e.Comments).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.IngredientId)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("IngredientID");
            entity.Property(e => e.Quantity).HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.RecipeId)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("RecipeID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Reference");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("Reference1");
        });

        modelBuilder.Entity<SwitchboardItem>(entity =>
        {
            entity.HasKey(e => new { e.SwitchboardId, e.ItemNumber }).HasName("PrimaryKey");

            entity.ToTable("Switchboard Items");

            entity.Property(e => e.SwitchboardId)
                .HasDefaultValue(0)
                .HasAnnotation("Jet:Identity", "($, $)")
                .HasColumnName("SwitchboardID");
            entity.Property(e => e.ItemNumber)
                .HasDefaultValue((short)0)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Argument)
                .HasMaxLength(50)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.Command)
                .HasDefaultValue((short)0)
                .HasAnnotation("Jet:Identity", "($, $)");
            entity.Property(e => e.ItemText)
                .HasMaxLength(255)
                .HasAnnotation("Jet:Identity", "($, $)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
