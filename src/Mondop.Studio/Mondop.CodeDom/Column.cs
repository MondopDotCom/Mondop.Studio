namespace Mondop.CodeDom
{
    public class Column
    {
        public string Name { get; set; }
        public string SqlType { get; set; }
        public int Size { get; set; }
        public int Precision { get; set; }
        public bool Mandatory { get; set; }
        public string ExplicitType { get; set; }
    }
}
