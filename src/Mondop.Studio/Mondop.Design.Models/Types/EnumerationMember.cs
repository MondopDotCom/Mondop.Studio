namespace Mondop.Design.Models.Types
{
    //public class EnumerationMember
    //{
    //    public string Name { get; set; }
    //    public int? Value { get; set; }
    //}

    public class EnumeationMemberDefinition: DesignObjectDefinition
    {
        public EnumeationMemberDefinition()
        {
            this.Name = "EnumerationMember";
            this.Properties.Add(new DesignObjectPropertyDefinition
            {
                Name = "Name",
                Type = "string",
            });
            this.Properties.Add(new DesignObjectPropertyDefinition
            {
                Name = "Value",
                Type = "int32",
                Nullable = true
            });
        }
    }
}
