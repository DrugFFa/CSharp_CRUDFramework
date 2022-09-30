using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAPP_SIBKMNET.Context;
using WebAPP_SIBKMNET.Models;

namespace WEBAPP_SIBKMNET2.Controllers
{
    public class ProvinceController : Controller
    {
        MyContext myContext;

        public ProvinceController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //GETALL
        public IActionResult index()
        {
            var data = myContext.Provinces.Include(x => x.Region).ToList();
            return View(data);
        }

        //GetByID

        public IActionResult Details(int id)
        {
            var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault(x => x.Id.Equals(id));
            return View(data);
        }

        //Create
        //GET

        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province province)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    myContext.Provinces.Add(province);
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }


            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = myContext.Provinces.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Province Model)
        {
            var data = myContext.Provinces.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id= Model.Id;
                data.Name = Model.Name;
                data.RegionId = Model.RegionId;
                
                myContext.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var data = myContext.Provinces.Where(x => x.Id == id).FirstOrDefault();
            myContext.Provinces.Remove(data);
            myContext.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}