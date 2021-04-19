using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mhcapstone.Data;
using mhcapstone.Models;
using Microsoft.AspNet.Identity;

namespace mhcapstone.Controllers
{
    public class SurveyInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveyInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: SurveyInfoes/Details/5
        public async Task<IActionResult> Questions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyQuestions = await _context.SurveyInfo
                .FirstOrDefaultAsync(m => m.SurveysId == id);

            var userID = (String)User.Identity.GetUserId(); 

            var groupedQuestions = _context.SurveyInfo.Where(c => (c.SurveysId == surveyQuestions.SurveysId)).ToList();

            if (surveyQuestions == null)
            {
                return NotFound();
            }

            return View(groupedQuestions);
        }

        public async Task<IActionResult> QuestionsAnswered(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyQuestions = await _context.SurveyInfoTaken
                .FirstOrDefaultAsync(m => m.SurveysId == id);

            var userID = (String)User.Identity.GetUserId();

            var groupedQuestions = _context.SurveyInfoTaken.Where(c => (c.SurveysId == surveyQuestions.SurveysId)).Where(c => (c.UserID == userID)).ToList();

            if (surveyQuestions == null)
            {
                return NotFound();
            }

            return View(groupedQuestions);
        }


        // GET: SurveyInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyInfo.ToListAsync());
        }

        // GET: SurveyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyInfo = await _context.SurveyInfo
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
            return View();
        }

        // POST: SurveyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Questions,Answers,SurveysId,ID,TimeStamp, UserID")] SurveyInfo surveyInfo)
        {
            surveyInfo.SurveysId = _context.Survey.Max(i => i.ID);
            surveyInfo.TimeStamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                surveyInfo.UserID = User.Identity.GetUserId();
                _context.Add(surveyInfo);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create","SurveyInfoes");

            }
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
            return View(surveyInfo);
        }

        // POST: SurveyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Questions,Answers,SurveysId,ID,TimeStamp")] SurveyInfo surveyInfo)
        {
            surveyInfo.TimeStamp = DateTime.Now;
            if (id != surveyInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SurveyInfoTaken surveyInfoTaken = new SurveyInfoTaken {

                        Questions = surveyInfo.Questions,
                        Answers = surveyInfo.Answers,
                        SurveysId = surveyInfo.SurveysId,
                        UserID = User.Identity.GetUserId(),

                    };
                    _context.Add(surveyInfoTaken);
                    _context.SaveChanges();
                    surveyInfo.Answers = null;
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
                return RedirectToAction("Questions", "SurveyInfoes", new { id = surveyInfo.SurveysId });
            }
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
