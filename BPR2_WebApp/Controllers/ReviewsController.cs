using BPR2_WebApp.DTO;
using BPR2_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private ApiHelper apiHelper = new ApiHelper();

        [HttpPost]
        public ActionResult Load(IFormCollection collection)
        {
            var s = collection["StoreName"].ToString();
            if (s == null)
            {
                s = "";
            }

            List<ReviewDTO> dTOs = apiHelper.GetReviews().Result;
            var models = new List<ReviewModel>();

            dTOs.ForEach(r =>
            {
                if (r != null)
                {
                    if (r.StoreName.ToLower().Equals(s.ToLower()) || s.Equals(""))
                    {
                        var rm = new ReviewModel() { Id = r.Id, Username = r.Username, Rating = r.Rating, Comment = r.Comment, StoreName = r.StoreName };
                        models.Add(rm);
                    }
                }
            });

            var model = new ReviewsModel() { StoreName = s, Reviews = models };
            return View("Index", model);
        }

        // GET: ReviewsController
        public ActionResult Index()
        {
            List<ReviewDTO> dTOs = apiHelper.GetReviews().Result;
            var models = new List<ReviewModel>();

            dTOs.ForEach(r =>
            {
                if (r != null)
                {
                    var rm = new ReviewModel() { Id = r.Id, Username = r.Username, Rating = r.Rating, Comment = r.Comment, StoreName = r.StoreName };
                    models.Add(rm);
                }
            });

            var model = new ReviewsModel() { StoreName = "", Reviews = models };
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
