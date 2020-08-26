using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class Project: CodeObject
    {
        public string Name { get; set; }
        public List<Database> Databases { get; set; } = new List<Database>();
        public List<Module> Modules { get; set; } = new List<Module>();

        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
