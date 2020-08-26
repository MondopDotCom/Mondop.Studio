namespace Mondop.CodeDom
{
    public class DeleteDatabaseCommand: DatabaseCommand
    {
        public string Schema { get; set; }
        public string TableName { get; set; }
        public bool AutoDeleteType { get; set; }
        public TypeReference Type { get; set; }
    }
}
