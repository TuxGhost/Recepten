namespace Recepten.Aspire.Web.Models;
/// <summary>
/// DTO model for use in website.
/// </summary>
public class RecipeModel
{
    public required int RecipeId { get; set; }
    public required string RecipeName { get; set; }
    public string? RecipeDescription { get; set; }
    public string? Source { get; set; }

    public string? WhichMeal { get; set; }

    public int? FoodCategoryId { get; set; }

    public bool? Vegetarian { get; set; }

    public string? TimeToPrepare { get; set; }

    public short? NumberofServings { get; set; }

    public short? CaloriesPerServing { get; set; }

    public string? NutritionalInformation { get; set; }

    public string? Ingredients { get; set; }

    public string? Instructions { get; set; }

    public string? Notes { get; set; }

    public string? Utensils { get; set; }

    //public virtual FoodCategory? FoodCategory { get; set; }

    //public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
