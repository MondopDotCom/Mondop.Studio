namespace Mondop.Design.Models
{
    public class DesignObject
    {
        public string Name { get; set; }
        public string Namespace { get; set; }

        public Module Module { get; set; }

        public string QualifiedName => !string.IsNullOrWhiteSpace(Namespace) ? $"{Namespace}.{Name}" : Name;
    }
}
