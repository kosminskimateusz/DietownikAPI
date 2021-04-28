using System;
using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.SavedRecipes
{
    public class UpdateSavedRecipeRequest : IRequest<UpdateSavedRecipeResponse>
    {
        public int id;
        public decimal PreferedKcal { get; set; }
    }
}