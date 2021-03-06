﻿using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Api.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetNotes()
        {
            var service = new NoteService();
            var userId = User.Identity.GetUserId();
            var notes = service.GetAllForUser(Guid.Parse(userId));

            return Ok(notes);
        }
    }
}
