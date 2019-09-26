using ClassLibrary1;
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
    public class Class1ApiController : ApiController
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: api/Class1Api
        public IQueryable<Class1> GetClass1()
        {
            return db.Class1;
        }

        // GET: api/Class1Api/5
        [ResponseType(typeof(Class1))]
        public async Task<IHttpActionResult> GetClass1(int id)
        {
            Class1 class1 = await db.Class1.FindAsync(id);
            if (class1 == null)
            {
                return NotFound();
            }

            return Ok(class1);
        }

        // PUT: api/Class1Api/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClass1(int id, Class1 class1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != class1.Id)
            {
                return BadRequest();
            }

            db.Entry(class1).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class1Exists(id))
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

        // POST: api/Class1Api
        [ResponseType(typeof(Class1))]
        public async Task<IHttpActionResult> PostClass1(Class1 class1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Class1.Add(class1);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = class1.Id }, class1);
        }

        // DELETE: api/Class1Api/5
        [ResponseType(typeof(Class1))]
        public async Task<IHttpActionResult> DeleteClass1(int id)
        {
            Class1 class1 = await db.Class1.FindAsync(id);
            if (class1 == null)
            {
                return NotFound();
            }

            db.Class1.Remove(class1);
            await db.SaveChangesAsync();

            return Ok(class1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Class1Exists(int id)
        {
            return db.Class1.Count(e => e.Id == id) > 0;
        }
    }
}