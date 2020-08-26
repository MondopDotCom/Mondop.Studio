namespace Mondop.Design.Models.Types
{
    public class Entity: ComplextTypeDeclaration<EntityProperty>
    {
        public Entity()
        {
            Extends = new TypeReference { ReferencedType = "Mondop.System.Entity" };
        }

        public string Database { get; set; }
        public string Schema { get; set; }
        public string TableName { get; set; }
    }
}
