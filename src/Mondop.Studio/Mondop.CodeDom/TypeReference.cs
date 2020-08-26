namespace Mondop.CodeDom
{
    public class TypeReference
    {
        public string Namespace { get; set; }
        public string Type { get; set; }

        public string QualifiedName => $"{Namespace}.{Type}";
    }
}
