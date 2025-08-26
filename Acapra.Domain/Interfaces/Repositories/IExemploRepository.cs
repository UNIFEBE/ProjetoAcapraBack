using Acapra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Domain.Interfaces.Repositories
{
    public interface IExemploRepository
    {
        List<PetModel> ListPets();
    }
}
