using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class UpdateField
    {
        public string Name { get; set; }
        public CodeExpression Source { get; set; }
    }

    public class UpdateDatabaseCommand: DatabaseCommand
    {
        public string Schema { get; set; }
        public string TableName { get; set; }

        public bool AutoUpdateType { get; set; }
        public TypeReference Type { get; set; }
        public List<UpdateField> Fields { get; set; } = new List<UpdateField>();
    }
}
