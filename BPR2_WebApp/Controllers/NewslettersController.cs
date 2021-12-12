using BPR2_WebApp.DTO;
using BPR2_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BPR2_WebApp.Controllers
{
    [Authorize]
    public class NewslettersController : Controller
    {
        private ApiHelper apiHelper = new ApiHelper();
        private List<NewsletterModel> newsletters = new List<NewsletterModel>();

        public IActionResult Index()
        {
            List<NewsletterDTO> dTOs = apiHelper.GetNewsletters().Result;

            dTOs.ForEach(n => newsletters.Add(new NewsletterModel() { Id = n.Id, Title = n.Title, Details = n.Details, ValidFrom = n.ValidFrom, ValidTo = n.ValidTo }));
            return View(newsletters);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = newsletters.Find(n => n.Id.Equals(id));
            if(newsletter != null)
            {
                return View(newsletter);
            }

            var dto = apiHelper.GetNewsletter(id.GetValueOrDefault()).Result;
            if(dto == null)
            {
                return NotFound();
            }
            var model = new NewsletterModel() { Id = dto.Id, Title = dto.Title, Details = dto.Details, ValidFrom = dto.ValidFrom, ValidTo = dto.ValidTo };
            newsletters.Add(model);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            var title = collection["Title"].ToString();
            var details = collection["Details"].ToString();
            var validTo = DateTime.Parse(collection["ValidTo"].ToString());
            var validFrom = DateTime.Parse(collection["ValidFrom"].ToString());
            var dto = new NewsletterDTO();

            if (ModelState.IsValid)
            {
                dto = new NewsletterDTO() {Title = title, Details = details, ValidFrom = validFrom, ValidTo = validTo };
                var result = apiHelper.PostNewsletter(dto).Result;
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            var newsletter = new NewsletterModel() { Id = dto.Id, Title = dto.Title, Details = dto.Details, ValidFrom = dto.ValidFrom, ValidTo = dto.ValidTo };
            newsletters.Add(newsletter);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = newsletters.Find(n => n.Id.Equals(id));
            if (newsletter != null)
            {
                return View(newsletter);
            }

            var dto = apiHelper.GetNewsletter(id.GetValueOrDefault()).Result;
            if (dto == null)
            {
                return NotFound();
            }
            var model = new NewsletterModel() { Id = dto.Id, Title = dto.Title, Details = dto.Details, ValidFrom = dto.ValidFrom, ValidTo = dto.ValidTo };
            newsletters.Add(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, IFormCollection collection)
        {
            var title = collection["Title"].ToString();
            var details = collection["Details"].ToString();
            var validTo = DateTime.Parse(collection["ValidTo"].ToString());
            var validFrom = DateTime.Parse(collection["ValidFrom"].ToString());
            var dto = new NewsletterDTO();

            if (ModelState.IsValid)
            {
                dto = new NewsletterDTO() { Id = id, Title = title, Details = details, ValidFrom = validFrom, ValidTo = validTo };
                var result = apiHelper.UpdateNewsletter(id, dto).Result;
                if(result != null)
                    return RedirectToAction("Details", "Newsletters", new { id = id });
            }
            var oldNewsletter = newsletters.FirstOrDefault(n => n.Id == id);
            if(oldNewsletter != null)
            {
                newsletters.Remove(oldNewsletter);
                var model = new NewsletterModel() { Id = dto.Id, Title = dto.Title, Details = dto.Details, ValidFrom = dto.ValidFrom, ValidTo = dto.ValidTo };
                newsletters.Add(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            var newsletter = newsletters.Find(n => n.Id.Equals(id));
            if (newsletter != null)
            {
                return View(newsletter);
            }

            var dto = apiHelper.GetNewsletter(id).Result;
            if (dto == null)
            {
                return NotFound();
            }
            var model = new NewsletterModel() { Id = dto.Id, Title = dto.Title, Details = dto.Details, ValidFrom = dto.ValidFrom, ValidTo = dto.ValidTo };
            newsletters.Add(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id, IFormCollection collection)
        {
            var newsletter = apiHelper.RemoveNewsletter(id).Result;
            if (newsletter == null)
            {
                return NotFound();
            }
            var remove = newsletters.FirstOrDefault(p => p.Id == id);
            if (remove != null)
                newsletters.Remove(remove);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
