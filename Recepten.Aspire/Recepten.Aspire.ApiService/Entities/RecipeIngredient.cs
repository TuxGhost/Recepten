using System;
using System.Collections.Generic;

namespace Recepten.Aspire.ApiService.Entities;

public partial class RecipeIngredient
{
    public int RecipeIngredientId { get; set; }

    public int RecipeId { get; set; }

    public int? IngredientId { get; set; }

    public double? Quantity { get; set; }

    public string? Comments { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
