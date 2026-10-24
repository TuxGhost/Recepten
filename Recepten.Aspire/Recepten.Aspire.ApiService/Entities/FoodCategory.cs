using System;
using System.Collections.Generic;

namespace Recepten.Aspire.ApiService.Entities;

public partial class FoodCategory
{
    public int FoodCategoryId { get; set; }

    public string? FoodCategory1 { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
