using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using Task1.Models.ViewModels;

namespace Task1.Controllers
{
    public class CRUDDoctorsController : Controller
    {
        private readonly DoctorsContext _context;
        public CRUDDoctorsController(DoctorsContext context)
        {
            _context = context;
        }
        public IActionResult DoctorsList()
        {
            var doktors = (from d in _context.doctors
                           select new DoctorsIndexViewModel
                           {
                               Row = d.Row,
                               DoctorID = d.DoctorID,
                               BirthDate = d.BirthDate,
                               Desc = d.Desc,
                               Family = d.Family,
                               Image = d.Image,
                               MyProperty = d.MyProperty,
                               Name = d.Name,
                               OfficeImage = d.OfficeImage,
                           }).ToList();
            return View(doktors);
        }
        public async Task<IActionResult>  Index()
        {
            
            return View(await _context.doctors.ToListAsync());
        }
                //اگر نخوایم برنامه نویسی موازی کار کنیم
        //public  IActionResult Index()
        //{
        //    return View( _context.doctors.ToList());
        //}
        [HttpGet]
        public IActionResult Create()
        {
            DoctorsCreateEditViewModel EditCearteVM = new DoctorsCreateEditViewModel() ;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsCreateEditViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = new Doctor()
                {
                    Row = ViewModel.Row,
                    Name = ViewModel.Name,
                    DoctorID = ViewModel.DoctorID,
                    BirthDate= ViewModel.BirthDate,
                    Desc= ViewModel.Desc,
                    Family= ViewModel.Family,
                    Image= ViewModel.Image,
                    MyProperty= ViewModel.MyProperty,
                    OfficeImage= ViewModel.OfficeImage,
                };
                _context.doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                var doctor = _context.doctors.FindAsync(id);
                if (doctor==null)
                {
                    return NotFound();
                }
                else
                {
                    var ViewModel = (from d in _context.doctors where (d.DoctorID == id)
                                     select new DoctorsCreateEditViewModel {
                                         Row = d.Row,
                                         DoctorID = d.DoctorID,
                                         BirthDate = d.BirthDate,
                                         Desc = d.Desc,
                                         Family = d.Family,
                                         Image = d.Image,
                                         MyProperty = d.MyProperty,
                                         Name = d.Name,
                                         OfficeImage = d.OfficeImage,
                                     }).FirstAsync();
                    return View(await ViewModel);
                }
            }
           

            //کدها قبل از ادیت جدید به درستی کار می کردند
            //if (id==null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    var doctor = await _context.doctors.FirstOrDefaultAsync(m => m.DoctorID == id);
            //    if (doctor==null)
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        return View(doctor);
            //    }
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorsCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = new Doctor()
                {
                    Row = viewModel.Row,
                    Name = viewModel.Name,
                    DoctorID = viewModel.DoctorID,
                    BirthDate = viewModel.BirthDate,
                    Desc = viewModel.Desc,
                    Family = viewModel.Family,
                    Image = viewModel.Image,
                    MyProperty = viewModel.MyProperty,
                    OfficeImage = viewModel.OfficeImage,
                };
                _context.Update(doctor);
                await _context.SaveChangesAsync();
                ViewBag.msgSuccess = "ذخیره موفق تغییرات";
                return View(viewModel);
                //return RedirectToAction("index");
            }
            else
            {
                ViewBag.msgFailed = "اطلاعات فرم نامعتبر است";
                return View(viewModel);
            }
        }

        //قبل تغییرات درست کار می کرد
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Doctor doctor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(doctor);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("index");
        //    }
        //    return View(doctor);
        //}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                var doctor = await _context.doctors.FirstOrDefaultAsync(m => m.DoctorID == id);
                if (doctor==null)
                {
                    return NotFound();
                }
                else
                {
                    return View(doctor);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleted(int? id)
        {
            var doctor = await _context.doctors.FindAsync(id);
            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}