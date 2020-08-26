namespace Mondop.Design.Models.Types
{
    public class ClassTypeProperty
    {
        public Scope Scope { get; set; }
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool Required { get; set; }
        public bool ReadOnly { get; set; }
    }
}
