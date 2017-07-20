using System;

namespace Domain
{
    public class SocialSecurityNumber : IComparable<SocialSecurityNumber>
    {
        public SocialSecurityNumber(string areaNumber, string groupNumber, string serialNumber)
        {
            // Skipping validation
            AreaNumber = areaNumber;
            GroupNumber = groupNumber;
            SerialNumber = serialNumber;
        }

        public string AreaNumber { get; }
        public string GroupNumber { get; }
        public string SerialNumber { get; }

        public override string ToString()
        {
            return $"{AreaNumber}-{GroupNumber}-{SerialNumber}";
        }

        public int CompareTo(SocialSecurityNumber socialSecurityNumber)
        {
            return String.Compare(ToString(), socialSecurityNumber.ToString(), StringComparison.Ordinal);
        }
    }
}