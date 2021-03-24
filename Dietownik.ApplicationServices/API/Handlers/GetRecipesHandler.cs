using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers
{
    public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, GetRecipesResponse>
    {
        private readonly IRepository<Recipe> recipeRepository;
        private readonly IMapper mapper;

        public GetRecipesHandler(IRepository<Recipe> recipeRepository, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }
        public async Task<GetRecipesResponse> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await this.recipeRepository.GetAll();
            var mappedRecipes = this.mapper.Map<List<Domain.Models.Recipe>>(recipes);

            var response = new GetRecipesResponse()
            {
                Data = mappedRecipes
            };

            return response;
        }
    }
}