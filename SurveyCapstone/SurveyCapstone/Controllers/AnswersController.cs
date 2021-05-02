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
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Answers.Include(a => a.Question).Include(a => a.Response).Where(n=>n.ResponseId == id).Where(s=>s.UserID == User.Identity.GetUserId());
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Results(int id, string user)
        {
            var applicationDbContext = _context.Answers.Include(a => a.Question).Include(a => a.Response).Include(u => u.User).Where(n => n.ResponseId == id).Where(x => x.UserID == user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.Response)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Questions/Create
        public IActionResult Create(int id)
        {

            var count = _context.Questions.Where(i => i.SurveyId == id).Count();

            var answer = _context.Answers.Where(i => i.UserID == User.Identity.GetUserId()).Where(i => i.ResponseId == id).Count();
            ViewData["answer"] = answer;

            ViewData["count"] = count;


            ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id");

            if(answer == count)
            {
                return RedirectToAction("SurveyLandingPage", "Extras");
            }
            else
            {
                ViewData["QuestionId"] = new SelectList(_context.Questions.Where(i => i.SurveyId == id), "Id", "Title").Skip(answer);
            }

           
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(int id, Answer model)
        {
            model.UserID = User.Identity.GetUserId();
            model.ResponseId = _context.Responses.Max(i => i.Id);
            model.Id = _context.Answers.Count() + 1;
            model.ResponseId = id;
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();
            var count = _context.Questions.Where(i => i.SurveyId == id).Count();

            var answer = _context.Answers.Where(i => i.UserID == User.Identity.GetUserId()).Select(i => i.ResponseId).Count();

            ViewData["answer"] = answer;

            ViewData["count"] = count;


            ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id");

            if (answer == count)
            {
                return RedirectToAction("SurveyLandingPage", "Extras");
            }
            else
            {
                ViewData["QuestionId"] = new SelectList(_context.Questions.Where(i => i.SurveyId == id), "Id", "Title").Skip(answer);
            }
            return RedirectToAction("Create", "Answers", new  { id = id});
        }

        //// GET: Answers/Create
        //public IActionResult Create()
        //{
        //    ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
        //    ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id");
        //    return View();
        //}

        //// POST: Answers/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ResponseId,QuestionId,Value,Comment")] Answer answer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(answer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionId);
        //    ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id", answer.ResponseId);
        //    return View(answer);
        //}

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionId);
            ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id", answer.ResponseId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponseId,QuestionId,Value,Comment")] Answer answer)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.Id))
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionId);
            ViewData["ResponseId"] = new SelectList(_context.Responses, "Id", "Id", answer.ResponseId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.Response)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.Id == id);
        }
    }
}
