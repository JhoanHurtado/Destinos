using Destinos.Data.Interface;
using Destinos.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Destino.Business.Business
{
    public class PlaceBusiness
    {
        private IPlace _place;

        public PlaceBusiness(IPlace place)
        {
            _place = place;
        }

        public Place Add(Place p) {
            try
            {
                var place = _place.Add(p);
                return place;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Place> Find(Expression<Func<Place, bool>> filtro)
        {
            var places = _place.Find(filtro);
            return places;
        }

        public List<Place> Get()
        {
            var places = _place.Get();
            return places;
        }

        public Place Update(Place p)
        {
            try
            {
                var r = _place.Update(p);
                return r;
            }
            catch (Exception ex)
            {
                throw;
            }      
        }

        public bool Delete(Place p, bool deleteAll)
        {
            try
            {
                if (deleteAll || p.Count < 1)
                {
                   return _place.Delete(p);
                }
                p.Count--;
                _place.Update(p);
                return true;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
