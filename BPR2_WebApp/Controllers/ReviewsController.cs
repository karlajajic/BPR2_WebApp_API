using BPR2_WebApp.DTO;
using BPR2_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private ApiHelper apiHelper = new ApiHelper();
       
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

            //var model = new SoldProductsModel() { Date = d, Products = models };
            return View("Index", models);
        }

    }
}
