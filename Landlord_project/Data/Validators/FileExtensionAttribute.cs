using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Landlord_project.Data.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionAttribute : ValidationAttribute
    {
        #region Fields
        private List<string> AllowedExt { get; set; }
        #endregion

        #region Constructor
        public FileExtensionAttribute(string fileExt)
        {
            AllowedExt = fileExt.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        #endregion

        #region Methods
        public override bool IsValid(object value)
        {
            var file = (IFormFile)value;

            if (file != null)
            {
                var fileName = file.FileName;

                return AllowedExt.Any(str => fileName.EndsWith(str));
            }
            return true;
        }
        #endregion
    }
}
