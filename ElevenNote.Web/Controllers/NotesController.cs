using ElevenNote.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            var notes = new List<NoteListViewModel>();
            notes.Add(new NoteListViewModel()
            {
                Id = 0,
                DateCreated = DateTime.UtcNow,
                DateModified = null,
                IsFavorite = true,
                Title = "Some note title"
            });

            notes.Add(new NoteListViewModel()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow.AddMonths(-1),
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "Some note title 2.0"
            });

            notes.Add(new NoteListViewModel()
            {
                Id = 2,
                DateCreated = DateTime.UtcNow.AddMonths(-2),
                DateModified = DateTime.UtcNow.AddMonths(1),
                IsFavorite = true,
                Title = "Some note title 3.0"
            });

            notes.Add(new NoteListViewModel()
            {
                Id = 3,
                DateCreated = DateTime.UtcNow.AddMonths(-3),
                DateModified = DateTime.UtcNow.AddMonths(2),
                IsFavorite = false,
                Title = "Some note title 4.0"
            });

            return View(notes);
        }
    }
}