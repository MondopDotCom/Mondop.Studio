using System;
using System.Collections.Generic;
using System.Text;

namespace Mondop.CodeDom
{
    public class InsertField
    {
        public string Name { get; set; }
        public CodeExpression Source { get; set; }
    }

    public class OutputField
    {
        public string Name { get; set; }
        public CodeExpression Target { get; set; }
    }
    public class InsertDatabaseCommand: DatabaseCommand
    {
        public string Schema { get; set; }
        public string TableName { get; set; }
        public bool AutoInsertType { get; set; }
        public TypeReference Type {get; set; }

        public List<InsertField> Fields {get; set; } = new List<InsertField>();
        public List<OutputField> Output {get; set; } = new List<OutputField>();
    }
}
