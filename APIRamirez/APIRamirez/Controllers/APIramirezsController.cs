using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIRamirez.Models;

namespace APIRamirez.Controllers
{
    public class APIramirezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/APIramirezs
        [Authorize]
        public IQueryable<APIramirez> GetAPIramirezs()
        {
            return db.APIramirezs;
        }

        // GET: api/APIramirezs/5
        [Authorize]
        [ResponseType(typeof(APIramirez))]
        public IHttpActionResult GetAPIramirez(int id)
        {
            APIramirez aPIramirez = db.APIramirezs.Find(id);
            if (aPIramirez == null)
            {
                return NotFound();
            }

            return Ok(aPIramirez);
        }

        // PUT: api/APIramirezs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPIramirez(int id, APIramirez aPIramirez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPIramirez.RamirezID)
            {
                return BadRequest();
            }

            db.Entry(aPIramirez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIramirezExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIramirezs
        [Authorize]
        [ResponseType(typeof(APIramirez))]
        public IHttpActionResult PostAPIramirez(APIramirez aPIramirez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APIramirezs.Add(aPIramirez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aPIramirez.RamirezID }, aPIramirez);
        }

        // DELETE: api/APIramirezs/5
        [Authorize]
        [ResponseType(typeof(APIramirez))]
        public IHttpActionResult DeleteAPIramirez(int id)
        {
            APIramirez aPIramirez = db.APIramirezs.Find(id);
            if (aPIramirez == null)
            {
                return NotFound();
            }

            db.APIramirezs.Remove(aPIramirez);
            db.SaveChanges();

            return Ok(aPIramirez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APIramirezExists(int id)
        {
            return db.APIramirezs.Count(e => e.RamirezID == id) > 0;
        }
    }
}