using Destinos.Data.Interface;
using Destinos.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Destinos.Data.Implementacion
{
    public class PlaceImpelementacion : IPlace
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public Place Add(Place p)
        {
            _appDbContext.Entry(p).State = EntityState.Added;
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return p;
        }

        public bool Delete(Place p)
        {
            _appDbContext.Entry(p).State = EntityState.Deleted;
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Place> Find(Expression<Func<Place, bool>> filtro)
        {
            var places = _appDbContext.Set<Place>().Where(filtro).ToList();
            return places;
        }

        public List<Place> Get()
        {
            var places = _appDbContext.Set<Place>().ToList();
            return places;
        }

        public Place Update(Place p)
        {
            _appDbContext.Entry(p).State = EntityState.Modified;
            try
            {
               var r = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return p;
        }
    }
}
