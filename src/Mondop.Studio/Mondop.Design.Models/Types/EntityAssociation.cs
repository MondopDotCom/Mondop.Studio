namespace Mondop.Design.Models.Types
{
    public class EntityAssociation
    {
        public string From { get; set; }
        public string FromType { get; set; }
        public string To { get; set; }
        public string ToType { get; set; }
        public EntityAssociationType Type { get; set; }

        public TypeDeclaration InstanceForm { get; set; }
        public TypeDeclaration InstanceTo { get; set; }
    }
}
