using mhcapstone.Data;
using mhcapstone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Controllers
{
    public class SurveyAndQuestionController : Controller
    {
        private ApplicationDbContext _context;
        public SurveyAndQuestionController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SurveyInfoes/Details/5
        //public async Task<IActionResult> Index(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var surveyInfo = await _context.SurveyInfo
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (surveyInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(surveyInfo);
        //}

        public IActionResult Index()
        {
            List<SurveyAndQuestion> list = new List<SurveyAndQuestion>();

            var r = (from s in _context.Survey
                     join q in _context.SurveyInfo on s.ID equals q.SurveysId
                     select new SurveyAndQuestion()
                     {
                         Title = s.Title,
                         UserID = s.UserID,
                         User = s.User,
                         Questions = q.Questions,
                         Answers = q.Answers,
                         SurveysId = q.SurveysId,
                     }).ToList();

            foreach (var i in r)
            {
                SurveyAndQuestion objr = new SurveyAndQuestion();
                objr.Title = i.Title;
                objr.UserID = i.UserID;
                objr.User = i.User;
                objr.Questions = i.Questions;
                objr.Answers = i.Answers;
                objr.SurveysId = i.SurveysId;

                list.Add(objr);
            }

            return View(list);
        }
    }
}
