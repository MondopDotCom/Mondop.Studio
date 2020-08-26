namespace Mondop.Design.Models.Types
{
    public class Interface : ComplextTypeDeclaration<InterfaceProperty>
    {
        public Interface()
        {
            Extends = new TypeReference { ReferencedType = "Mondop.System.Interface" };
        }
    }
}
