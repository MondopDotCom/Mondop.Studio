using System.Collections.Generic;

namespace Mondop.Design.Models
{
    public class Project
    {
        public string Name { get; set; }
        public List<Module> Modules { get; set; }
        public List<Application> Applications { get; set; }
    }
}