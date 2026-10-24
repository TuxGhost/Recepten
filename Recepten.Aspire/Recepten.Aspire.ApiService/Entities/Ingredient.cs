using System;
using System.Collections.Generic;

namespace Recepten.Aspire.ApiService.Entities;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string? Ingredient1 { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
