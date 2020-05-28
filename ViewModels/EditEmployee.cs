using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDotNetCore.ViewModels
{
    public class EditEmployee : EmployeeCreateViewModel
    {
        public int  Id { get; set; }
        public  string  ExistingPhotoPath { get; set; }
    }
}
