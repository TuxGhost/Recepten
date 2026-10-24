using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepten.Aspire.ApiService.Data;
using Recepten.Aspire.ApiService.Entities;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Recepten.Aspire.ApiService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ReceptenController : ControllerBase
{
    private readonly BomDbContext _db;
    public ReceptenController(BomDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<IEnumerable<object>> ObjectsAsync()        
    {                
        var result = await _db.Recipes.ToListAsync();
        return result.Cast<object>().ToList();
    }
    [HttpGet]
    public async Task<IEnumerable<Recipe>> RecipesAsync()
    {
        var result = await _db.Recipes.ToListAsync();
          return result.ToList();
    }
    [HttpGet]
    public async Task<IEnumerable<Ingredient>> IngredientsAsync()
    {
        var result = await _db.Ingredients.ToListAsync();
        return result.ToImmutableList();
    }
    [HttpGet]
    public async Task<IEnumerable<FoodCategory>> CategoriesAsync()
    {
        var result = await _db.FoodCategories.ToListAsync();
        return result.ToImmutableList();
    }
}
