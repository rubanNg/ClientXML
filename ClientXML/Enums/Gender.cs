using System.Runtime.Serialization;

namespace ClientXML.Enums
{
    public enum Gender
    {
        [EnumMember(Value = "М")]
        Male,
        [EnumMember(Value = "Ж")]
        Female,
        [EnumMember(Value = "")]
        Unknown,
    }
}
