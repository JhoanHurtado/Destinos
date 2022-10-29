using Destinos.Data.Interface;
using Destinos.Data.Models;
using Destinos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Destinos.Controllers
{
    public class DestinoController : Controller
    {
   
        private readonly IPlace _IPlace;

        public DestinoController(IPlace iPlace)
        {
            _IPlace = iPlace;
        }



        // GET: Destino
        public ActionResult Index()
        {

            List<DestinoDto> d = new List<DestinoDto>();
            var p = _IPlace.Get();
            foreach (var item in p)
            {
                d.Add(
                    new DestinoDto() { 
                        Id = item.Id, 
                        Count = item.Count, 
                        NamePlace = item.NamePlace, 
                        LocationPlace = item.LocationPlace 
                    }
                    );
            }
            return View(d);
        }

        // GET: Destino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var destinoDto = _IPlace.Find(x => x.Id == id);
            if (destinoDto == null)
            {
                return HttpNotFound();
            }
            return View(
            new DestinoDto()
            {
                Id = destinoDto.FirstOrDefault().Id,
                Count = destinoDto.FirstOrDefault().Count,
                NamePlace = destinoDto.FirstOrDefault().NamePlace,
                LocationPlace = destinoDto.FirstOrDefault().LocationPlace
            });
        }

        // GET: Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NamePlace,LocationPlace,Count")] DestinoDto destinoDto)
        {
            if (ModelState.IsValid)
            {
                _IPlace.Add(new Place()
                {
                    Id = destinoDto.Id,
                    Count = destinoDto.Count,
                    NamePlace = destinoDto.NamePlace,
                    LocationPlace = destinoDto.LocationPlace
                });
                return RedirectToAction("Index");
            }

            return View(destinoDto);
        }

        // GET: Destino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var destinoDto = _IPlace.Find(x => x.Id == id);
            if (destinoDto == null)
            {
                return HttpNotFound();
            }
            return View(
            new DestinoDto()
            {
                Id = destinoDto.FirstOrDefault().Id,
                Count = destinoDto.FirstOrDefault().Count,
                NamePlace = destinoDto.FirstOrDefault().NamePlace,
                LocationPlace = destinoDto.FirstOrDefault().LocationPlace
            });
        }

        // POST: Destino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NamePlace,LocationPlace,Count")] DestinoDto destinoDto)
        {
            if (ModelState.IsValid)
            {
                _IPlace.Update(new Place()
                {
                    Id = destinoDto.Id,
                    Count = destinoDto.Count,
                    NamePlace = destinoDto.NamePlace,
                    LocationPlace = destinoDto.LocationPlace
                });
                return RedirectToAction("Index");
            }
            return View(destinoDto);
        }

        //GET: Destino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var destinoDto = _IPlace.Find(x => x.Id == id).FirstOrDefault();
            if (destinoDto == null)
            {
                return HttpNotFound();
            }
            return View(new DestinoDto()
            {
                Id = destinoDto.Id,
                Count = destinoDto.Count,
                NamePlace = destinoDto.NamePlace,
                LocationPlace = destinoDto.LocationPlace
            });
        }

        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = _IPlace.Find(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                _IPlace.Delete(p);

            }
            return RedirectToAction("Index");
        }

    }
}
