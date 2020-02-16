using System;
using System.Text.RegularExpressions;

namespace SortArray.Helpers
{
    public static class Validation
    {
        /// <summary>Validate input.</summary>
        public static string ValidateInput(string inputType, string input)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrEmpty(inputType))
            {
                return "Please Enter Valid Input";
            }
            else if(input.Split(",").Length > 100)
            {
                return "Input size must be between 1 to 100 values";
            }
            else if(inputType == "Numbers")
            {
                Regex regex = new Regex(@"^\d+(,\d+)*$");
                var match = regex.Match(input);
                if(!match.Success)
                {
                    return "Please Enter valid comma separated Numeric values."+
                    "\n string should not start or end with comma."+
                    "\n only integers separated with comma are allowed."+
                    "\n Input size is 1 to 100 values.";
                }
                else
                {
                    int[] ary = Array.ConvertAll(input.Split(","), int.Parse);
                    for(int i=0; i<ary.Length; i++)
                    {
                        if(ary[i] > int.MaxValue)
                        {
                            return "Numeric values should be less than max or equal integer size";
                        }
                    }
                } 
            }
            else if(inputType == "Strings")
            {
                Regex regex = new Regex(@"^[\d\w@./#&+-]+[\d+\w+\s,@./#&+-]*[\.\w\d@./#&+-]$");
                var match = regex.Match(input);
                if(!match.Success)
                {
                    return "Please Enter Valid comma separated String values."+
                    "\n String should not start or end with whitespace or comma."+
                    "\n Special characters are allowed in strings"+
                    "\n Each string value should not exceed 10 Characters"+
                    "\n Input size is 1 to 100 values";
                }
                else
                {
                    string[] ary = input.Split(",");
                    for(int i=0; i<ary.Length; i++)
                    {
                        if(ary[i].Length > 10)
                        {
                            return "String values should be up to 10 characters long";
                        }
                    }
                }
            }

            return "";
        }
    }
}