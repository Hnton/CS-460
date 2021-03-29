using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mhcapstone.Data;
using mhcapstone.Models;

namespace mhcapstone.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Survey.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveys = await _context.Survey
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveys == null)
            {
                return NotFound();
            }

            return View(surveys);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,UserCount,Title,ID,TimeStamp")] Surveys surveys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", surveys.UserID);
            return View(surveys);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveys = await _context.Survey.FindAsync(id);
            if (surveys == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", surveys.UserID);
            return View(surveys);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,UserCount,Title,ID,TimeStamp")] Surveys surveys)
        {
            if (id != surveys.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveysExists(surveys.ID))
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
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", surveys.UserID);
            return View(surveys);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveys = await _context.Survey
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveys == null)
            {
                return NotFound();
            }

            return View(surveys);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveys = await _context.Survey.FindAsync(id);
            _context.Survey.Remove(surveys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveysExists(int id)
        {
            return _context.Survey.Any(e => e.ID == id);
        }
    }
}
