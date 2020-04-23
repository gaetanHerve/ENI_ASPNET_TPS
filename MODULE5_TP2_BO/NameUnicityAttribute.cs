using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MODULE5_TP2_BO
{
    // Not Used
    public class NameUnicityAttribute : ValidationAttribute
    {
        public int Id { get; set; }
        public List<string> ExistingNames { get; set; } = new string[] { "" }.ToList();

        public override bool IsValid(object name)
        {
            string strName = name as string;
            foreach (string item in this.ExistingNames)
            {
                if (strName == item)
                    return false;
            }
            return true;
        }
    }
}

