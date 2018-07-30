﻿using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly EventCatalogContext _eventCatalogContext;

        public EventController(EventCatalogContext eventCatalogContext)
        {
            _eventCatalogContext = eventCatalogContext;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> EventTypes()
        {
            var items = await _eventCatalogContext.EventTypes.ToListAsync();
            return Ok(items);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items = await _eventCatalogContext.EventCategories.ToListAsync();
            return Ok(items);
        }


        [HttpGet]
        [Route("events/{id:int}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var item = await _eventCatalogContext.Events
                .SingleOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
                //item.PictureUrl = item.PictureUrl
                // .Replace("http://externalcatalogbaseurltobereplaced",
                //_settings.Value.ExternalCatalogBaseUrl);
                return Ok(item);
            }
           
            return NotFound();
        }

        [HttpPost]
        [Route("events")]
        public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
        {

            var item = new Event
            {
                EventCategoryId = newEvent.EventCategoryId,
                EventTypeId = newEvent.EventTypeId,
                StartDate = newEvent.StartDate,
                EndDate = newEvent.EndDate,
                Price = newEvent.Price,
                ImageUrl = newEvent.ImageUrl
                
            };
            _eventCatalogContext.Events.Add(item);
            await _eventCatalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventById), new { id = item.Id });
        }


        [HttpPut]
        [Route("events")]
        public async Task<IActionResult> UpdateEvent(
            [FromBody] Event eventToUpdate)
        {
            var catalogEvent = await _eventCatalogContext.Events
                              .SingleOrDefaultAsync
                              (i => i.Id == eventToUpdate.Id);
            if (catalogEvent == null)
            {
                return NotFound(new { Message = $"Item with id {eventToUpdate.Id} not found." });
            }
            catalogEvent = eventToUpdate;
            _eventCatalogContext.Events.Update(catalogEvent);
            await _eventCatalogContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventById), new { id = eventToUpdate.Id });
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var catalogEvent = await _eventCatalogContext.Events
                .SingleOrDefaultAsync(p => p.Id == id);
            if (catalogEvent == null)
            {
                return NotFound();

            }
            _eventCatalogContext.Events.Remove(catalogEvent);
            await _eventCatalogContext.SaveChangesAsync();
            return NoContent();

        }

    }
}