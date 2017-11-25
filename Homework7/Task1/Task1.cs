using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	/// <summary>
	/// Customer class has three public properties - Name (string), ContactPhone (string) and Revenue (decimal). 
	/// Implement for the Customer's objects the capability of a various string representation. For example, 
	/// the object with the Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100"
	/// can have the following string representation:	
	/// Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100 
	/// Customer record: +1 (425) 555-0100 
	/// Customer record: Jeffrey Richter, 1,000,000.00 
	/// Customer record: Jeffrey Richter 
	/// Customer record: 1000000, etc.
	/// Add to Customer class an additional formatting capability, that is not provided by the class (Customer class do
	/// not change). Develop unit tests. 
	/// /// </summary>
	class Task1
    {
        static void Main(string[] args)
        {
        }
    }

    public class Customer:IFormattable
    {
		string _name, _contactPhone;
		double _revenue;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
                if (String.IsNullOrEmpty(value)) throw new ArgumentException("argument is null or empty string", nameof(value));
                _name = value;
			}
		}
        public double Revenue
		{
			get
			{
				return _revenue;
			}
			set
			{
                if (Double.IsNaN(value)
                    || Double.IsInfinity(value)
                    ) throw new ArgumentException("argument in NaN or Infinity", nameof(value));
                _revenue = value;
			}
		}
		public string ContactPhone
		{
			get
			{
				return _contactPhone;
			}
			set
			{
				if (String.IsNullOrEmpty(value)) throw new ArgumentException("argument is null or empty string", nameof(value));
                _contactPhone = value;
            }
		}

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider != null)
            {
                if (formatProvider.GetFormat(this.GetType()) is ICustomFormatter formatter) return formatter.Format(format, this, formatProvider);
            }
            //if (format == null) format = "\0";
            if (format == null) format = String.Empty;
            var sb = new StringBuilder();
            sb.Append("Customer record: ");
            foreach(char c in format)
            {
                switch (c)
                {
                    case 'N':
                        sb.Append(this.Name);
                        sb.Append(" ");
                        break;
                    case 'R':
                        sb.Append(this.Revenue.ToString());
                        sb.Append(" ");
                        break;
                    case 'P':
                        sb.Append(this.ContactPhone);
                        sb.Append(" ");
                        break;
                    default:
                        sb.Append(this.Name);
                        sb.Append(" ");
                        sb.Append(this.Revenue);
                        sb.Append(" ");
                        sb.Append(this.ContactPhone);
                        break;
                }
            }
            
            return sb.ToString();
        }
    }
    
}

