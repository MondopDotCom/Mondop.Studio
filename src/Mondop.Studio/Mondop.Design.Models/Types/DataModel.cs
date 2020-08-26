using System.Collections.Generic;

namespace Mondop.Design.Models.Types
{
    public class DataModel
    {
        public List<SystemType> SystemTypes { get; set; }
        public List<Enumeration> Enumerations { get; set; }
        public List<PrimitiveType> PrimitiveTypes { get; set; }
        public List<SimpleType> SimpleTypes { get; set; }
        public List<Class> Classes { get; set; }
        public List<Interface> Interfaces { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<Entity> Entities { get; set; }
        public List<EntityAssociation> EntityAssociations { get; set; }
    }
}
