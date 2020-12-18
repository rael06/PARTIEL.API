using System;
namespace PARTIEL.RAEL.CALITRO.API.Core.CSV
{
    public class CSVAttribute : Attribute
    {
        public int Order { get; set; }

        public CSVAttribute(int order)
        {
            Order = order;
        }
    }
}
