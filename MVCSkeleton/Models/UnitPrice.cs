using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVCSkeleton.Models
{
    public class UnitPrice
    {
        private readonly double unitValue;
        //private readonly DataType dataType;
        //private readonly NumberFormatInfo format;

        public UnitPrice(double unitValue/*, DataType dataType, NumberFormatInfo format*/)
        {
            this.unitValue = unitValue;
            //this.dataType = dataType;
            //this.format = format;
        }

        public override string ToString()
        {
            NumberFormatInfo LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = "€";
            //return unitValue.ToString(dataType, format);
            return unitValue.ToString("c", LocalFormat);
        }
    }
}