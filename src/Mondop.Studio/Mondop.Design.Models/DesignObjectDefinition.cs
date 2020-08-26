using System.Collections.Generic;

namespace Mondop.Design.Models
{
    public class DesingObjectAttributeDefinitionProperty
    {
        public string Name { get; set; }
    }

    public class DesingObjectAttributeDefinition
    {
        public string Name { get; set; }
        public List<DesingObjectAttributeDefinitionProperty> Properties { get; set; } = new List<DesingObjectAttributeDefinitionProperty>();
    }

    public class DesignObjectPropertyDefinition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public bool ReadOnly { get; set; }
        public List<DesingObjectAttributeDefinition> Attributes { get; set; } = new List<DesingObjectAttributeDefinition>();
    }

    public class DesignObjectDefinition
    {
        public string Name { get; set; }
        public string[] Extends { get; set; }

        public List<DesingObjectAttributeDefinition> Attributes { get; set; } = new List<DesingObjectAttributeDefinition>();
        public List<DesignObjectPropertyDefinition> Properties { get; set; } = new List<DesignObjectPropertyDefinition>();
    }
}
