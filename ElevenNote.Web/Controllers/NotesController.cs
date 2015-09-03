using ElevenNote.Models.ViewModels;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {

        public ActionResult Index()
        {
            if (TempData["Result"] != null)
            { 
                ViewBag.Success = TempData["Result"] ?? "";
                TempData.Remove("Result");
            }

            var notesService = new NoteService();
            var notes = notesService.GetAllForUser(Guid.Parse(User.Identity.GetUserId()));
            return View(notes);
        }

        // GET: Notes
        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userID = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Create(model, userID);
                TempData.Add("Result", result ? "Note Added." : "Note Not Added.");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Edit Stuff
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int ID)
        {
            var noteService = new NoteService();
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(ID, userID));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userID = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Update(model, userID);
                TempData.Add("Result", result ? "Note Updated." : "Note Not Updated.");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Details stuff
        public ActionResult Details(int ID)
        {
            var noteService = new NoteService();
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(ID, userID));
        }

        //Delete stuff
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int ID)
        {
            var noteService = new NoteService();
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(ID, userID));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int ID)
        { 
            var noteService = new NoteService();
            var userID = Guid.Parse(User.Identity.GetUserId());
            var result = noteService.Delete(ID, userID);
            TempData.Add("Result", result ? "Note Deleted." : "Note Not Delete.");
            return RedirectToAction("Index");
        }
    }
}