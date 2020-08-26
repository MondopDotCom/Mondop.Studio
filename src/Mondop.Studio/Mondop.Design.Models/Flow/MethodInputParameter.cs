using Mondop.Design.Models.Types;

namespace Mondop.Design.Models.Flow
{
    public enum MethodInputParameterDirection
    {
        In,
        Out,
        Ref
    };

    public class MethodInputParameter
    {
        public string Name { get; set; }
        public bool AllowEmpty { get; set; }
        public TypeReference Type { get; set; }
        public MethodInputParameterDirection Direction { get; set; }
        public string Default { get; set; }
    }
}
