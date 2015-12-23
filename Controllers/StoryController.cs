using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Story_Maker_Sridhar.Models;

namespace Online_Story_Maker_Sridhar.Controllers
{
    public class StoryController : Controller
    {
        private StoryContext db = new StoryContext();

        // GET: /Story/
        [Authorize]
        public ActionResult Index()
        {
            var tix = db.StoryTable
            .OrderBy(t => t.StorySeq)
            .ToList();
            return View(tix);
        }

        [Authorize]
        public ActionResult StoryBlockInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story_Table story_table = db.StoryTable.Find(id);

            var imgv = from s in db.ImageTable
                       where s.StoryId == id
                       select s;
            imgv = imgv.OrderBy(s => s.ImageSequence);


            if (story_table == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Story/StoryBlockInfo.cshtml", imgv);
        }


        [Authorize]
        public ActionResult SlideShow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story_Table story_table = db.StoryTable.Find(id);

            var imgvr = from s in db.ImageTable
                        where s.StoryId == id
                        select s;
            imgvr = imgvr.OrderBy(s => s.ImageSequence);

            if (story_table == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/Story/SlideShow.cshtml", imgvr);
        }

        [Authorize]

        // GET: /Story/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story_Table story_table = db.StoryTable.Find(id);
            var imgvr = from s in db.ImageTable
                        where s.StoryId == id
                        select s;
            imgvr = imgvr.OrderBy(s => s.ImageSequence);

            if (story_table == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Image/Index.cshtml", imgvr);
        }

        [Authorize(Roles = "developer")]
        // GET: /Story/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Story/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "developer")]
        public ActionResult Create([Bind(Include="StoryId,StoryName,StorySeq,AuthorName,DateandTimeCreated,DateandTimeModified,Importantevel,speed,TimerInterval,var1,var2,var3,num1,num2,num3")] Story_Table story_table)
        {
            if (ModelState.IsValid)
            {
                db.StoryTable.Add(story_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(story_table);
        }

        [Authorize(Roles = "developer")]
        // GET: /Story/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story_Table story_table = db.StoryTable.Find(id);
            if (story_table == null)
            {
                return HttpNotFound();
            }
            return View(story_table);
        }

        // POST: /Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "developer")]
        public ActionResult Edit([Bind(Include="StoryId,StoryName,StorySeq,AuthorName,DateandTimeCreated,DateandTimeModified,Importantevel,speed,TimerInterval,var1,var2,var3,num1,num2,num3")] Story_Table story_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story_table);
        }

        [Authorize(Roles = "admin")]
        // GET: /Story/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story_Table story_table = db.StoryTable.Find(id);
            if (story_table == null)
            {
                return HttpNotFound();
            }
            return View(story_table);
        }

        // POST: /Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Story_Table story_table = db.StoryTable.Find(id);
            db.StoryTable.Remove(story_table);
            db.SaveChanges();
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
