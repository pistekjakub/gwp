using Microsoft.VisualBasic.FileIO;

namespace gwp.Models.Database
{
    public class Record
    {
        public string Country { get; set; } = string.Empty;

        public string Lob { get; set; } = string.Empty;

        public double Y2000 { get; set; }

        public double Y2001 { get; set; }

        public double Y2002 { get; set; }

        public double Y2003 { get; set; }

        public double Y2004 { get; set; }

        public double Y2005 { get; set; }

        public double Y2006 { get; set; }

        public double Y2007 { get; set; }

        public double Y2008 { get; set; }

        public double Y2009 { get; set; }

        public double Y2010 { get; set; }

        public double Y2011 { get; set; }

        public double Y2012 { get; set; }

        public double Y2013 { get; set; }

        public double Y2014 { get; set; }

        public double Y2015 { get; set; }

        public static Record FromCsv(string csvLine) 
        {
            var parser = new TextFieldParser(new StringReader(csvLine));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            var values = parser.ReadFields();
            return new Record
            {
                Country = values?.Length > 0 && !string.IsNullOrEmpty(values[0]) ? values[0] : string.Empty,
                Lob = values?.Length > 0 && !string.IsNullOrEmpty(values[3]) ? values[3] : string.Empty,
                Y2000 = values?.Length > 3 && double.TryParse(values[4], out double parsedValue) ? parsedValue : 0.0,
                Y2001 = values?.Length > 4 && double.TryParse(values[5], out double parsedValue1) ? parsedValue1 : 0.0,
                Y2002 = values?.Length > 5 && double.TryParse(values[6], out double parsedValue2) ? parsedValue2 : 0.0,
                Y2003 = values?.Length > 6 && double.TryParse(values[7], out double parsedValue3) ? parsedValue3 : 0.0,
                Y2004 = values?.Length > 7 && double.TryParse(values[8], out double parsedValue4) ? parsedValue4 : 0.0,
                Y2005 = values?.Length > 8 && double.TryParse(values[9], out double parsedValue5) ? parsedValue5 : 0.0,
                Y2006 = values?.Length > 9 && double.TryParse(values[10], out double parsedValue6) ? parsedValue6 : 0.0,
                Y2007 = values?.Length > 10 && double.TryParse(values[11], out double parsedValue7) ? parsedValue7 : 0.0,
                Y2008 = values?.Length > 11 && double.TryParse(values[12], out double parsedValue8) ? parsedValue8 : 0.0,
                Y2009 = values?.Length > 12 && double.TryParse(values[13], out double parsedValue9) ? parsedValue9 : 0.0,
                Y2010 = values?.Length > 13 && double.TryParse(values[14], out double parsedValue10) ? parsedValue10 : 0.0,
                Y2011 = values?.Length > 14 && double.TryParse(values[15], out double parsedValue11) ? parsedValue11 : 0.0,
                Y2012 = values?.Length > 15 && double.TryParse(values[16], out double parsedValue12) ? parsedValue12 : 0.0,
                Y2013 = values?.Length > 16 && double.TryParse(values[17], out double parsedValue13) ? parsedValue13 : 0.0,
                Y2014 = values?.Length > 17 && double.TryParse(values[18], out double parsedValue14) ? parsedValue14 : 0.0,
                Y2015 = values?.Length > 18 && double.TryParse(values[19], out double parsedValue15) ? parsedValue15 : 0.0
            };
        }
    }
}
