using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.ApiControllers
{
    public class Class2ApiController : ApiController
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: api/Class2Api
        public IQueryable<Class2> GetClass2()
        {
            return db.Class2;
        }

        // GET: api/Class2Api/5
        [ResponseType(typeof(Class2))]
        public async Task<IHttpActionResult> GetClass2(int id)
        {
            Class2 class2 = await db.Class2.FindAsync(id);
            if (class2 == null)
            {
                return NotFound();
            }

            return Ok(class2);
        }

        // PUT: api/Class2Api/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClass2(int id, Class2 class2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != class2.Id)
            {
                return BadRequest();
            }

            db.Entry(class2).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class2Exists(id))
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

        // POST: api/Class2Api
        [ResponseType(typeof(Class2))]
        public async Task<IHttpActionResult> PostClass2(Class2 class2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Class2.Add(class2);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = class2.Id }, class2);
        }

        // DELETE: api/Class2Api/5
        [ResponseType(typeof(Class2))]
        public async Task<IHttpActionResult> DeleteClass2(int id)
        {
            Class2 class2 = await db.Class2.FindAsync(id);
            if (class2 == null)
            {
                return NotFound();
            }

            db.Class2.Remove(class2);
            await db.SaveChangesAsync();

            return Ok(class2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Class2Exists(int id)
        {
            return db.Class2.Count(e => e.Id == id) > 0;
        }
    }
}