using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using oop3.Data;
using projectY.Models;
using projectY.Manager;


namespace projectY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IManagerUser _manager;

        public UsersController(IManagerUser manager)
        {
            _manager = manager;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var User = await _manager.GetUsersAsync();
            return Ok(User);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _manager.GetUserByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            var success = await _manager.UpdateUserAsync(id, User);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            var createdUser = await _manager.CreateUserAsync(User);
            return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _manager.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        //// GET: Years
        //[HttpGet(Name = "Users")]
        //public async Task<IActionResult> Index()
        //{
        //    var data = await _manager.GetAll();
        //    return Json(data);
        //    //return Json(await _manager.Year.ToListAsync());
        //}

        // GET: Years/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var year = await _manager.Year
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (year == null)
        //    {
        //        return NotFound();
        //    }

        //    return Json(year);
        //}

        //// GET: Years/Create
        ////public IActionResult Create()
        //public JsonResult Create()
        //{
        //    var jsonOptions = new System.Text.Json.JsonSerializerOptions {//тут чтото можно написать хз что
        //    };
        //    //return View();
        //    return Json(jsonOptions);
        //}

        //// POST: Years/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Year year)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.Add(year);
        //        await _manager.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Json(year);
        //}

        //// GET: Years/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var year = await _manager.Year.FindAsync(id);
        //    if (year == null)
        //    {
        //        return NotFound();
        //    }
        //    return Json(year);
        //}

        //// POST: Years/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Year year)
        //{
        //    if (id != year.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _manager.Update(year);
        //            await _manager.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!YearExists(year.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Json(year);
        //}

        //// GET: Years/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var year = await _manager.Year
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (year == null)
        //    {
        //        return NotFound();
        //    }

        //    return Json(year);
        //}

        //// POST: Years/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var year = await _manager.Year.FindAsync(id);
        //    if (year != null)
        //    {
        //        _manager.Year.Remove(year);
        //    }

        //    await _manager.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool YearExists(int id)
        //{
        //    return _manager.Year.Any(e => e.Id == id);
        //}
    }
}
