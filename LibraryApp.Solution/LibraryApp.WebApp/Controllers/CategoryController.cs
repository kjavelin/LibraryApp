﻿using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.WebApp.NotifyModels;
using System.Web.Mvc;

namespace LibraryApp.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("CategoryList", "Home");
        }

        // GET: Category/Create
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryManager categoryManager = new CategoryManager();
                var blResultCategory = categoryManager.AddCategory(category);
                if (blResultCategory.ErrorMessageObj.Count > 0)
                {
                    ErrorViewModel errorViewModel = new ErrorViewModel()
                    {
                        Items = blResultCategory.ErrorMessageObj,
                    };
                    return View("Error", errorViewModel);
                }
                OkViewModel okViewModel = new OkViewModel()
                {
                    RedirectingUrl = "/Category/Index",
                    Title = "Kategori Eklendi"
                };

                return View("Ok", okViewModel);
            }

            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return View("Error", new ErrorViewModel()
                {
                    Title = "Hata yaptınız.."
                });
            }

            var blResultCategory = new CategoryManager().DeleteCategory(id);

            if (blResultCategory.ErrorMessageObj.Count > 0)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Items = blResultCategory.ErrorMessageObj,
                    RedirectingUrl = "/Home/CategoryList"
                };
                return View("Error", errorViewModel);
            }

            OkViewModel okViewModel = new OkViewModel()
            {
                Title = "Kategoriyi başarıyla sildiniz..",
                RedirectingUrl = "/Home/CategoryList"
            };
            return View("Ok", okViewModel);
        }
    }
}