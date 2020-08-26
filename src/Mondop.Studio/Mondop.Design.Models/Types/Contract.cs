namespace Mondop.Design.Models.Types
{
    // Contracts can not be implementented bij ClassType Declarations.
    // They are used for code generation.
    public class Contract: TypeDeclaration
    {
        public Contract()
        {
            Extends = new TypeReference { ReferencedType = "Mondop.System.Contract" };
        }

        public bool IsStatic { get; set; }
    }
}
