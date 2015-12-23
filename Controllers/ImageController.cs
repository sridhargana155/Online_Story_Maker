using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Online_Story_Maker_Sridhar.Models
{
    public class ImageController : Controller
    {
        private StoryContext db = new StoryContext();

        // GET: /Image/
        [Authorize]
        public ActionResult Index()
        {
            var imagetable = db.ImageTable.Include(i => i.Storydet);
            return View(imagetable.ToList());
        }
        [Authorize]
        public ActionResult ViewAllStoryBlocks()
        {
            var imagetable = db.ImageTable.Include(i => i.Storydet);
            return View(imagetable.ToList());
        }
        
        [Authorize]
        // GET: /Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image_Table image_table = db.ImageTable.Find(id);
            if (image_table == null)
            {
                return HttpNotFound();
            }
            return View(image_table);
        }


        // GET: /Image/Create
        [Authorize(Roles = "developer")]
        public ActionResult Create()
        {
            ViewBag.StoryId = new SelectList(db.StoryTable, "StoryId", "StoryName");
            return View();
        }

        // POST: /Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "developer")]
        public ActionResult Create([Bind(Include = "ImageID,ImageName,ImageCaption,ImageSequence,DateofCreation,DateofModification,ImageDescription,StoryId,ivar1,ivar2,ivar3,inum1,inum2,inum3")] Image_Table image_table)
        {
            if (ModelState.IsValid)
            {
                db.ImageTable.Add(image_table);
                db.SaveChangesforImage();
                return RedirectToAction("Index", "Story");
            }

            ViewBag.StoryId = new SelectList(db.StoryTable, "StoryId", "StoryName", image_table.StoryId);
            return View("~/Views/Story/Index.cshtml");
        }

          [Authorize]
        // GET: /Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image_Table image_table = db.ImageTable.Find(id);
            if (image_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoryId = new SelectList(db.StoryTable, "StoryId", "StoryName", image_table.StoryId);
            return View(image_table);
        }

        // POST: /Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "developer")]
        public ActionResult Edit([Bind(Include = "ImageID,ImageName,ImageCaption,ImageSequence,DateofCreation,DateofModification,ImageDescription,StoryId,ivar1,ivar2,ivar3,inum1,inum2,inum3")] Image_Table image_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image_table).State = EntityState.Modified;
                db.SaveChangesforImage();
                return RedirectToAction("Index", "Story");
            }
            ViewBag.StoryId = new SelectList(db.StoryTable, "StoryId", "StoryName", image_table.StoryId);
            return View(image_table);
        }

        // GET: /Image/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image_Table image_table = db.ImageTable.Find(id);
            if (image_table == null)
            {
                return HttpNotFound();
            }
            return View(image_table);
        }

        // POST: /Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Image_Table image_table = db.ImageTable.Find(id);
            db.ImageTable.Remove(image_table);
            db.SaveChangesforImage();
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
