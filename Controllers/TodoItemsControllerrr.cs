using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Models;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsControllerrr : ControllerBase
    {
        private readonly TodoContextt _context;

        public TodoItemsControllerrr(TodoContextt context)
        {
            _context = context;
        }

        // GET: api/TodoItemsControllerrr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemm>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TodoItemsControllerrr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemm>> GetTodoItemm(long id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var todoItemm = await _context.TodoItems.FindAsync(id);

            if (todoItemm == null)
            {
                return NotFound();
            }

            return todoItemm;
        }

        // PUT: api/TodoItemsControllerrr/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemm(long id, TodoItemm todoItemm)
        {
            if (id != todoItemm.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItemm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItemsControllerrr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemm>> PostTodoItemm(TodoItemm todoItemm)
        {
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'TodoContextt.TodoItems'  is null.");
          }
            _context.TodoItems.Add(todoItemm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItemm", new { id = todoItemm.Id }, todoItemm);
        }

        // DELETE: api/TodoItemsControllerrr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItemm(long id)
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }
            var todoItemm = await _context.TodoItems.FindAsync(id);
            if (todoItemm == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItemm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemmExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
