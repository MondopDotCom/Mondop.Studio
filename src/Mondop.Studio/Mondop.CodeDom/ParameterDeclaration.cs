namespace Mondop.CodeDom
{
    public class ParameterDeclaration: CodeObject
    {
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool AllowNull { get; set; }
    }
}