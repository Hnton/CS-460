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
            var userID = User.Identity.GetUserId();
            ViewData["userID"] = userID;

            //var t = from y in _context.Surveys.Include(s => s.User) where _context.Responses.Any(x => x.SurveyId != y.Id) select y;


            var applicationDbContext = _context.Surveys.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        //// GET: Surveys/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserID"] = new SelectList(_context.User, "Id", "Id");
        //    return View();
        //}

        //// POST: Surveys/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserID,Name,StartDate,EndDate")] Survey survey)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(survey);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", survey.UserID);
        //    return View(survey);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            var survey = new Survey
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            return View(survey);
        }

        [HttpPost]
        public ActionResult Create(Survey survey, string action)
        {
            if (ModelState.IsValid)
            {
                survey.StartDate = DateTime.Now;
                survey.EndDate = DateTime.Now;
                survey.Id = _context.Surveys.Count() + 1;
                survey.UserID = User.Identity.GetUserId();
                //survey.Questions.ForEach(q => q.CreatedOn = q.ModifiedOn = DateTime.Now);
                _context.Surveys.Add(survey);
                _context.SaveChanges();
                TempData["success"] = "The survey was successfully created!";
                return RedirectToAction("Create", "Questions", new { id = survey.Id });
            }
            else
            {
                TempData["error"] = "An error occurred while attempting to create this survey.";
                return View(survey);
            }
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{

        //    var survey = _context.Surveys.Include("Questions").Single(x => x.Id == id);
        //    return View(survey);
        //}

        //[HttpPost]
        //public ActionResult Edit(Survey model)
        //{

        //    foreach (var question in model.Questions)
        //    {
        //        model.UserID = User.Identity.GetUserId();

        //        question.SurveyId = model.Id;

        //        if (question.Id == 0)
        //        {
        //            question.CreatedOn = DateTime.Now;
        //            question.ModifiedOn = DateTime.Now;
        //            _context.Entry(question).State = EntityState.Added;
        //        }
        //        else
        //        {
        //            question.ModifiedOn = DateTime.Now;
        //            _context.Entry(question).State = EntityState.Modified;
        //            _context.Entry(question).Property(x => x.CreatedOn).IsModified = false;
        //        }
        //    }

        //    _context.Entry(model).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return RedirectToAction("Edit", new { id = model.Id });
        //}

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", survey.UserID);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Name,StartDate,EndDate")] Survey survey)
        {
            survey.UserID = User.Identity.GetUserId();
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.Id))
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
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", survey.UserID);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.Id == id);
        }
    }
}
