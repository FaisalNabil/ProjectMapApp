﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapProject.Models
{
    public class ImportExcel
    {
        [Required(ErrorMessage = "Please select file")]
        [FileExt(Allow = ".xls,.xlsx", ErrorMessage = "Only excel file")]
        public HttpPostedFileBase file { get; set; }
        public FileFor FileForType { get; set; }
    }

    public class FileExt : ValidationAttribute
    {
        public string Allow;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string extension = ((System.Web.HttpPostedFileBase)value).FileName.Split('.')[1];
                if (Allow.Contains(extension))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ErrorMessage);
            }
            else
                return ValidationResult.Success;
        }
    }

    public class YesNoClass
    {
        public static bool YesNo(string yesNo)
        {
            if (yesNo == "Yes")
                return true;
            else return false;
        }
    }

    public enum FileFor
    {
        General,
        SubSystem
    }
    public enum Renewable
    {
        Renewable = 1, Non_renewable = 2, Hybrid = 3, Other = 4
    }

}