using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public String ModuleName { get; set; }
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }

        [NotMapped]
        public string CourseName { get; set; }

        List<Module> list = new List<Module>();
        public List<Module> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Module mod = new Module();
                mod.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                
                mod.ModuleName = dt.Rows[i]["ModuleName"].ToString();
                //if (mod.CourseName != "")
                //{
                //    mod.CourseName = dt.Rows[i]["CourseName"].ToString();
                //}

                mod.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"]);
                list.Add(mod);
            }
            return list;
        }
    }
}