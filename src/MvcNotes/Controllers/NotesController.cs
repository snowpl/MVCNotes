using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcNotes.Models;
using System;
using Microsoft.AspNet.Http.Internal;
using System.Collections.Generic;

namespace MvcNotes.Controllers
{
    public class NotesController : Controller
    {
        private ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Notes

        public IActionResult Index(string noteHashtag, string SearchString)
        {
            var HashtagQry = from m in _context.Note
                           orderby m.Hashtag
                           select m.Hashtag;

            var HashtagList = new List<string>();
            HashtagList.AddRange(HashtagQry.Distinct());
            ViewData["noteHashtag"] = new SelectList(HashtagList);

            var notes = from m in _context.Note
                         select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                notes = notes.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(noteHashtag))
            {
                notes = notes.Where(x => x.Hashtag == noteHashtag);
            }

            return View(notes);
        }

        //    public IActionResult Index(string SearchString)
        //    {
        //        var notes = from m in _context.Note
        //                     select m;
        //
        //        if (!String.IsNullOrEmpty(SearchString))
        //        {
        //            notes = notes.Where(s => s.Title.Contains(SearchString));
        //        }
        //
        //        return View(notes);
        //    }


        // GET: Notes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Note note = _context.Note.Single(m => m.Id == id);
            if (note == null)
            {
                return HttpNotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Note.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Note note = _context.Note.Single(m => m.Id == id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Name, ReleaseDate, Title, NoteContents, Hashtag")]Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Note note = _context.Note.Single(m => m.Id == id);
            if (note == null)
            {
                return HttpNotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Note note = _context.Note.Single(m => m.Id == id);
            _context.Note.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
