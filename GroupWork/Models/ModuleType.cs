using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class ModuleType
    {
        [Key]
        public int Id { get; set; }
        public String ModuleTypeName { get; set; }

        List<ModuleType> list = new List<ModuleType>();
        public List<ModuleType> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModuleType modTyp = new ModuleType();
                modTyp.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                modTyp.ModuleTypeName = dt.Rows[i]["ModuleTypeName"].ToString();
                list.Add(modTyp);
            }
            return list;
        }
    }
}