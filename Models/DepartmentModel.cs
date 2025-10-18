using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // A department can have multiple people
        public ICollection<PersonModel> People { get; set; }
    }
}