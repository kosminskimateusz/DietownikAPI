using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietownik.ApplicationServices.Components
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool HashCheck(string passwordFromDatabase, string logginPassword);
    }
}
