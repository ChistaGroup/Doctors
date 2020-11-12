using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Task1.Models;
using Task1.Models.ViewModels;

namespace Task1.Areas.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorsContext _context;
        public DoctorsController(DoctorsContext context)
        {
            _context = context;
        }
        //یک اکشن متد که اطلاعات همه دکتر هارو برگردونه
        //[HttpGet]
        public List<DoctorsIndexViewModel> GetDoctors()
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
            return doktors;
        }

        [HttpGet("{id}")]
        public List<DoctorsIndexViewModel> GetADoctor(int id)
        {
            
            var Adoktor = (from d in _context.doctors where d.DoctorID==id
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
            return Adoktor;
        }


        [HttpPost]
       public async Task<string> CreateDoctor([FromBody]List<Doctor> doctors)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor1 = new Doctor();
                doctor1.Row = doctors[0].Row;
                doctor1.DoctorID = doctors[0].DoctorID;
                doctor1.Name = doctors[0].Name;
                doctor1.Family = doctors[0].Family;
                doctor1.Image = doctors[0].Image;
                doctor1.OfficeImage = doctors[0].OfficeImage;
                doctor1.BirthDate = doctors[0].BirthDate;
                doctor1.MyProperty = doctors[0].MyProperty;
                _context.doctors.Add(doctor1);
                await _context.SaveChangesAsync();
                return "عملیات با موفقیت انجام شد";
            }
            return "عملیات ناموفق";
        }

        [HttpPut("{id}")]
        public async Task<string> EditDoki(DoctorsCreateEditViewModel viewModel, int? id)
        {
            if (ModelState.IsValid)
            {
                //var tempid = await _context.doctors.FirstOrDefaultAsync(m => m.DoctorID == id);
                //if (tempid==null)
                //{
                //    return "مشخصات چنین پزشکی یافت نشد";
                //}
                //else
                //{
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
                    return "اطلاعات با موفقیت بروز رسانی شد";
                //} 
            }
            else
            {
                return "عدم بروز رسانی";
            }
        }
    }
}

