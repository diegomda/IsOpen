using Backend.helper;
using Backend.Models;
using Domain;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Backend.Controllers
{
    [Authorize(Roles="Admin")]
    public class NegociosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Negocios
        public async Task<ActionResult> Index()
        {
            var negocios = db.Negocios.Include(n => n.User);
            return View(await negocios.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NegocioView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/FotosNegocios";

                if (view.LogoFile != null)
                {
                    pic = FileHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                var negocio = ToNegocio(view);
                negocio.Logo = pic;
                db.Negocios.Add(negocio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", view.UserId);
            return View(view);
        }
        private Negocio ToNegocio(NegocioView view)
        {
            return new Negocio
            {
                NegocioId = view.NegocioId,
                Name = view.Name,
                Direccion = view.Direccion,
                Logo = view.Logo,
                Email = view.Email,
                Telefono = view.Telefono,
                Descripcion = view.Descripcion,
                UserId = view.UserId,
                Order = view.Order,
                IsActive = view.IsActive,
            };

        }
        // GET: Negocios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", negocio.UserId);
            var view = ToView(negocio);
            return View(view);
        }
        private NegocioView ToView(Negocio negocio)
        {
            return new NegocioView
            {
                NegocioId = negocio.NegocioId,
                Name = negocio.Name,
                Direccion = negocio.Direccion,
                Logo = negocio.Logo,
                Email = negocio.Email,
                Telefono = negocio.Telefono,
                Descripcion = negocio.Descripcion,
                UserId = negocio.UserId,
                Order = negocio.Order,
                IsActive = negocio.IsActive,
            };

        }
        // POST: Negocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NegocioView view)
        {
            if (ModelState.IsValid)
            {
                    var pic = view.Logo;
                    var folder = "~/Content/Fotos";

                    if (view.LogoFile != null)
                    {
                        pic = FileHelper.UploadPhoto(view.LogoFile, folder);
                        pic = string.Format("{0}/{1}", folder, pic);
                    }
                    var negocio = ToNegocio(view);
                    negocio.Logo = pic;
                    db.Entry(negocio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", view.UserId);
            return View(view);
        }

        // GET: Negocios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Negocio negocio = await db.Negocios.FindAsync(id);
            db.Negocios.Remove(negocio);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
