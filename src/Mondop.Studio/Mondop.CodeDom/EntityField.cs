namespace Mondop.CodeDom
{
    public class EntityField
    {
        public ScopeIdentifier Scope { get; set; }
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool Required { get; set; }
        public bool ReadOnly { get; set; }
        public string ColumnName { get; set; }
    }
}
