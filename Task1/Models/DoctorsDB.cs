using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models
{
    [Table("DoctorsInfo")]
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Row { get; set; }
        [Key][Required][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorID { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        public string Name { get; set; }
        public string Family { get; set; }
        [Column(TypeName ="image")]//چون میخوایم ستون معادل سطر زیر در دیتا بیس ایمیج باشه
        public byte[] Image { get; set; }//وقتی عکس تو دیتا بیس ذخیره میشه
        public string OfficeImage { get; set; }//وقتی عکس تو دیتا بیس ذخیره نمیشه
        public DateTime BirthDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTimeOffset MyProperty { get; set; }
        public string Desc { get; set; }
    }
}
