namespace Mondop.Design.Models.Types
{
    public class InterfaceProperty
    {
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool Required { get; set; }
        public bool ReadOnly { get; set; }
    }
}
