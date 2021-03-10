using System.Collections.Generic;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRepository<Recipe> recipeRepository;
        public RecipeController(IRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Recipe> GetAllRecipes() => this.recipeRepository.GetAll();
    }
}