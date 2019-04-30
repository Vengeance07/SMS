using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public String TeacherName { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public int AddressId { get; set; }
        public int ModuleTypeId { get; set; }
        public int ModuleId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Addresses { get; set; }

        [ForeignKey("ModuleTypeId")]
        public virtual ModuleType ModuleTypes { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Modules { get; set; }

        [NotMapped]
        public String Street { get; set; }

        [NotMapped]
        public String ModuleTypeName { get; set; }

        [NotMapped]
        public String ModuleName { get; set; }

        List<Teacher> list = new List<Teacher>();
        public List<Teacher> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Teacher tea = new Teacher();
                tea.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                if (dt.Columns.Contains("Street"))
                {
                       tea.Street = dt.Rows[i]["Street"].ToString();
                }
                if (dt.Columns.Contains("ModuleTypeName")){
                    tea.ModuleTypeName = dt.Rows[i]["ModuleTypeName"].ToString();

                }
                if (dt.Columns.Contains("ModuleName")){
                    tea.ModuleName = dt.Rows[i]["ModuleName"].ToString();
                }
                tea.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                tea.Contact = dt.Rows[i]["Contact"].ToString();
                tea.Email = dt.Rows[i]["Email"].ToString();

                list.Add(tea);
            }
            return list;
        }
    }
}