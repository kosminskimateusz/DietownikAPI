using System;
using Dietownik.ApplicationServices.API.Domain.Models;
using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.SavedRecipes
{
    public class GetSavedRecipesRequest : IRequest<GetSavedRecipesResponse>
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}