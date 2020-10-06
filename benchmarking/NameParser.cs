using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace benchmarking
{
    public class NameParser
    {
        private readonly Regex regex = new Regex(@"^(?<recordid>.{6})(?<invoicenumber>.{30})(?<invoicedate>.{10})(?<netamount>.{11})(?<grossamount>.{11})(?<discountamount>.{11})$");

        public void ExtractWithSubstring(string checkString)
        {
            var recordId = checkString.Substring(0, 6).Trim();
            var invoicenumber = checkString.Substring(7, 30).Trim();
            var invoicedate = checkString.Substring(37, 10).Trim();
            var netamount = checkString.Substring(47, 11).Trim();
            var grossamount = checkString.Substring(58, 11).Trim();
            var discountamount = checkString.Substring(69).Trim();
        
        }
        public void ExtractWithSubstringWithoutTrim(string checkString)
        {
            var recordId = checkString.Substring(0, 6);
            var invoicenumber = checkString.Substring(7, 30);
            var invoicedate = checkString.Substring(37, 10);
            var netamount = checkString.Substring(47, 11);
            var grossamount = checkString.Substring(58, 11);
            var discountamount = checkString.Substring(69);

        }

        public void ExtractValuesWithTextFieldParser(string checkString)
        {
            var parser = new TextFieldParser(new StringReader(checkString))
            {
                TextFieldType = FieldType.FixedWidth
            };
            parser.SetFieldWidths(6, 30, 10, 11,11,11);
            var row = parser.ReadFields();
            var recordId = row[0].Trim();
            var invoicenumber = row[1].Trim();
            var invoicedate = row[2].Trim();
            var netamount = row[3].Trim();
            var grossamount = row[4].Trim();
            var discountamount = row[5].Trim();

        }
        public void ExtractValuesWithTextFieldParserWithoutTrim(string checkString)
        {
            var parser = new TextFieldParser(new StringReader(checkString))
            {
                TextFieldType = FieldType.FixedWidth
            };
            parser.SetFieldWidths(6, 30, 10, 11, 11, 11);
            var row = parser.ReadFields();
            var recordId = row[0];
            var invoicenumber = row[1];
            var invoicedate = row[2];
            var netamount = row[3];
            var grossamount = row[4];
            var discountamount = row[5];

        }

        public void ExtractValuesWithSpan(ReadOnlySpan<char> checkString)
        {
          
            var recordId = checkString.Slice(0, 6).Trim();
            var invoicenumber = checkString.Slice(7, 30).Trim();
            var invoicedate = checkString.Slice(37, 10).Trim();
            var netamount = checkString.Slice(47, 11).Trim();
            var grossamount = checkString.Slice(58, 11).Trim();
            var discountamount = checkString.Slice(69).Trim();

       
        }
        public void ExtractValuesWithSpanWithoutTrim(ReadOnlySpan<char> checkString)
        {

            var recordId = checkString.Slice(0, 6);
            var invoicenumber = checkString.Slice(7, 30);
            var invoicedate = checkString.Slice(37, 10);
            var netamount = checkString.Slice(47, 11);
            var grossamount = checkString.Slice(58, 11);
            var discountamount = checkString.Slice(69);


        }

        public void ExtractValuesWithRegex(string checkString)
        {
            var values = regex.Match(checkString);
            var recordId = values.Groups["recordid"].Value.Trim();
            var invoicenumber = values.Groups["invoicenumber"].Value.Trim();
            var invoicedate = values.Groups["invoicedate"].Value.Trim();
            var netamount = values.Groups["netamount"].Value.Trim();
            var grossamount = values.Groups["grossamount"].Value.Trim();
            var discountamount = values.Groups["discountamount"].Value.Trim();
        }
        public void ExtractValuesWithRegexWithoutTrim(string checkString)
        {
            var values = regex.Match(checkString);
            var recordId = values.Groups["recordid"].Value;
            var invoicenumber = values.Groups["invoicenumber"].Value;
            var invoicedate = values.Groups["invoicedate"].Value;
            var netamount = values.Groups["netamount"].Value;
            var grossamount = values.Groups["grossamount"].Value;
            var discountamount = values.Groups["discountamount"].Value;
        }
    }
}