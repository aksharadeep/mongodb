﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IKeepService keepService;
        public NoteController(IKeepService service)
        {
            keepService = service;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(keepService.GetNotes());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(keepService.GetNoteById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            try
            {
                keepService.AddNote(note);
                return Created("api/note", note);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            try
            {
                return Ok(keepService.UpdateNote(id, note));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(keepService.DeleteNote(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}/label")]
        public IActionResult GetLabelsById(int id)
        {
            try
            {
                return Ok(keepService.GetLabels(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Label label)
        {
            try
            {
                keepService.AddLabel(id, label);
                return Created("api/note", label);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Label label)
        {
            try
            {
                keepService.UpdateLabel(id, label);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{nid}/label/{lid}")]
        public IActionResult Delete(int nid, int lid)
        {
            try
            {
                keepService.DeleteLabelByNoteIdAndLabelId(nid, lid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
