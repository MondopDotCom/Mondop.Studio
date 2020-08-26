using Mondop.Design.Models.Types;

namespace Mondop.Design.Models
{
    public class Module
    {
        public string Namespace { get; set; }
        public string ModuleName { get; set; }

        public DataModel DataModel { get; set; }
    }
}
