namespace Mondop.CodeDom
{
    public class InterfacePropertyDeclaration
    {
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool ReadOnly { get; set; }
        public bool Nullable { get; set; }
    }
}
