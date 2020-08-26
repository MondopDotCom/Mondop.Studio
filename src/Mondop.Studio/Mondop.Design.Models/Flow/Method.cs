namespace Mondop.Design.Models.Flow
{
    public class Method: DesignObject
    {
        public MethodResult Result { get; set; }
        public MethodInput Input { get; set; }
        public FlowBody Body { get; set; }
    }
}
