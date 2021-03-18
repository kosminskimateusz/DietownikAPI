using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers
{
    public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, GetRecipesResponse>
    {
        private readonly IRepository<Recipe> recipeRepository;

        public GetRecipesHandler(IRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        public Task<GetRecipesResponse> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = this.recipeRepository.GetAll();
            var domainRecipes = recipes.Select(recipe => new Domain.Models.Recipe()
            {
                Id = recipe.Id,
                Name = recipe.Name
            });

            var response = new GetRecipesResponse()
            {
                Data = domainRecipes.ToList()
            };

            return Task.FromResult(response);
        }
    }
}