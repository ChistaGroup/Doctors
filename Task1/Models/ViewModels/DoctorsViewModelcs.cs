using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models.ViewModels
{
    public class DoctorsCreateEditViewModel
    {
        [Display(Name ="ردیف")]
        public int Row { get; set; }

        [Display(Name ="شناسه دکتر")]
        [Required(ErrorMessage ="وارد نمودن {0} الزامی است")]
        public int DoctorID { get; set; }

        [Display(Name ="نام")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        public string Name { get; set; }

        [Display(Name ="نام خانوادگی")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        public string Family { get; set; }

        [Display(Name ="عکس دکتر")]
        public byte[] Image { get; set; }//وقتی عکس تو دیتا بیس ذخیره میشه

        [Display(Name ="عکس مطب")]
        public string OfficeImage { get; set; }//وقتی عکس تو دیتا بیس ذخیره نمیشه

        [Display(Name ="تاریخ تولد")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        public DateTime BirthDate { get; set; }

        [Display(Name ="تاریخ عضویت")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        public DateTimeOffset MyProperty { get; set; }

        [Display(Name ="توضیحات")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        public string Desc { get; set; }
    }

    public class DoctorsIndexViewModel
    {
        public int Row { get; set; }
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public byte[] Image { get; set; }//وقتی عکس تو دیتا بیس ذخیره میشه
        public string OfficeImage { get; set; }//وقتی عکس تو دیتا بیس ذخیره نمیشه
        public DateTime BirthDate { get; set; }
        public DateTimeOffset MyProperty { get; set; }
        public string Desc { get; set; }
    }
}
