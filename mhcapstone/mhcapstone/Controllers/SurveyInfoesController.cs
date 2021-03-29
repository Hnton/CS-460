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
    public class SurveyInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveyInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SurveyInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SurveyInfo.Include(s => s.Surveys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SurveyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyInfo = await _context.SurveyInfo
                .Include(s => s.Surveys)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyInfo == null)
            {
                return NotFound();
            }

            return View(surveyInfo);
        }

        // GET: SurveyInfoes/Create
        public IActionResult Create()
        {
            ViewData["SurveysID"] = new SelectList(_context.Survey, "ID", "ID");
            return View();
        }

        // POST: SurveyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Questions,Answers,SurveysID,ID,TimeStamp")] SurveyInfo surveyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SurveysID"] = new SelectList(_context.Survey, "ID", "ID", surveyInfo.SurveysID);
            return View(surveyInfo);
        }

        // GET: SurveyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyInfo = await _context.SurveyInfo.FindAsync(id);
            if (surveyInfo == null)
            {
                return NotFound();
            }
            ViewData["SurveysID"] = new SelectList(_context.Survey, "ID", "ID", surveyInfo.SurveysID);
            return View(surveyInfo);
        }

        // POST: SurveyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Questions,Answers,SurveysID,ID,TimeStamp")] SurveyInfo surveyInfo)
        {
            if (id != surveyInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyInfoExists(surveyInfo.ID))
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
            ViewData["SurveysID"] = new SelectList(_context.Survey, "ID", "ID", surveyInfo.SurveysID);
            return View(surveyInfo);
        }

        // GET: SurveyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyInfo = await _context.SurveyInfo
                .Include(s => s.Surveys)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyInfo == null)
            {
                return NotFound();
            }

            return View(surveyInfo);
        }

        // POST: SurveyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyInfo = await _context.SurveyInfo.FindAsync(id);
            _context.SurveyInfo.Remove(surveyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyInfoExists(int id)
        {
            return _context.SurveyInfo.Any(e => e.ID == id);
        }
    }
}
