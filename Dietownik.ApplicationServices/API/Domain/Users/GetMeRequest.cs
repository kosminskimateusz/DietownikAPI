using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietownik.ApplicationServices.API.Domain.Users
{
    public class GetMeRequest : IRequest<GetMeResponse>
    {
        public int id;
    }
}
