using Backend.helper;
using Backend.Models;
using Domain;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Backend.Controllers
{
    public class UsersController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        public async Task<ActionResult> CreateNegocio(int? id)
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

            var view = new Negocio { NegocioId = negocio.NegocioId, };
            return View(view);
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNegocio(Negocio view)
        {

            if (ModelState.IsValid)
            {
                db.Negocios.Add(view);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}",view.UserId));
            }

            return View(view);
        }
        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Fotos";

                if (view.LogoFile != null)
                {
                    pic = FileHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var user = ToUser(view);
                user.Logo = pic;

                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private User ToUser(UserView view)
        {
            return new User
            {
                UserId = view.UserId,
                Name = view.Name,
                Direccion = view.Direccion,
                Logo = view.Logo,
            };

        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var view = ToView(user);
            return View(view);
        }

        private UserView ToView(User user)
        {
            return new UserView
            {
                UserId = user.UserId,
                Name = user.Name,
                Direccion = user.Direccion,
                Logo = user.Logo,
            };
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserView view)
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

                var user = ToUser(view);
                user.Logo = pic; db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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
