namespace Mondop.Design.Models.Types
{
    public class Class: ComplextTypeDeclaration<ClassTypeProperty>
    {
        public Class()
        {
            Extends = new TypeReference { ReferencedType = "Mondop.System.Class" };
        }
    }
}
