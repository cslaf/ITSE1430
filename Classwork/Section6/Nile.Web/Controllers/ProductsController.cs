using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Nile.Data;
using Nile.Data.SQL;
using Nile.Web.Mcv.Models;

namespace Nile.Web.Mcv.Controllers
{
    public class ProductsController : Controller
    {

        public ProductsController()
        {
            var connString = @"(localdb)\ProjectsV13;Initial Catalog=NileDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _database = new SqlProductDatabase(connString);

        }

        private readonly IProductDatabase _database;

        [HttpGet]
        public IActionResult Index()
        {
            var products = _database.GetAll();
            return View(products.Select(p => p.ToModel()));
            //return Json(products.Select(p => p.ToModel()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _database.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
                
            return Json(product.ToModel());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public IActionResult Create (ProductModel model )
        {
            try
            {
                if (ModelState.IsValid)
                { 
                var product = model.ToProduct();

                    product = _database.Add(product);

                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var product = _database.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product.ToModel());
        }
        [HttpPost]
        public IActionResult Edit (ProductModel model )
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToProduct();

                    product = _database.Update(product);

                    return RedirectToAction("Index");
                    
                }
            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);

        }
        [HttpGet]
        [Route("products/delete/{id}")]
        public IActionResult Delete (int id )
        {
            var product = _database.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product.ToModel());
        }
        [HttpPost]
        public IActionResult Delete (ProductModel model)
        {

            try
            {
                var product = _database.GetAll().FirstOrDefault(p => p.Id == model.Id);

                if (product == null)
                    return NotFound();

                _database.Remove(model.Id);

                return RedirectToAction(nameof(Index));

            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);

        }
        
    }
}