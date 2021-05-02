using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurveyCapstone.Data;
using SurveyCapstone.Models;

namespace SurveyCapstone.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            var userID = User.Identity.GetUserId();
            ViewData["userID"] = userID;
            var applicationDbContext = _context.Responses.Include(r => r.Survey).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Results(int id)
        {
            var userID = User.Identity.GetUserId();
            ViewData["userID"] = userID;
            var applicationDbContext = _context.Responses.Include(r => r.Survey).Include(r => r.User).Where(c => c.SurveyId == id);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Responses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.Survey)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Responses/Create
        public IActionResult Create(int id)
        {
            ViewData["param"] = _context.Answers.Where(z => z.ResponseId == id).Where(c=>c.UserID == User.Identity.GetUserId()).Count();
            ViewData["SurveyId"] = new SelectList(_context.Surveys.Where(n=> n.Id == id), "Id", "Name");
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("Id,SurveyId,UserID,CreatedOn")] Response response)
        {

            if (ModelState.IsValid)
            {
                response.CreatedOn = DateTime.Now;
                response.UserID = User.Identity.GetUserId();
                response.Id = _context.Responses.Count() + 1;
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Answers", new { id = response.SurveyId });
            }
            ViewData["param"] = _context.Answers.Where(z => z.ResponseId == id).Count();
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Name", response.SurveyId);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", response.UserID);
            return View(response);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id", response.SurveyId);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", response.UserID);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyId,UserID,CreatedOn")] Response response)
        {
            if (id != response.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id", response.SurveyId);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", response.UserID);
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.Survey)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponseExists(int id)
        {
            return _context.Responses.Any(e => e.Id == id);
        }
    }
}
