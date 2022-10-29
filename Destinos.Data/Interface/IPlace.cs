using Destinos.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Destinos.Data.Interface
{
    public interface IPlace
    {
        Place Add(Place p); //TODO: registrar lugares
        List<Place> Get(); //TODO: Obtener ellistado completo de lugaes
        bool Delete(Place p); //TODO: Eliminar un lugar
        List<Place> Find(Expression<Func<Place, bool>> filtro); //TODO: filtrar los lugares por un parametro cualquiera

        Place Update(Place p);
    }
}
