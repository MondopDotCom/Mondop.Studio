using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class AttributeReference
    {
        public string Namespace { get; set; }
        public string AttributeType { get; set; }

        public string QualifiedName => $"{Namespace}.{AttributeType}";

        public List<ParameterValue> Parameters { get; set; } = new List<ParameterValue>();
    }
}
