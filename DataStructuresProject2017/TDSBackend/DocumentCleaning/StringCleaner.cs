using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDSBackend.DocumentCleaning
{
    class StringCleaner
    {

        public string clean(string file)
        {
            string cleanString = "";
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == '\'')
                {
                    //System.Diagnostics.Debug.WriteLine("Found apostrophe");
                }
                else if (file[i] == '!')
                {
                    //System.Diagnostics.Debug.WriteLine("Found exclamation point");
                }
                else if (file[i] == '.')
                {
                    //System.Diagnostics.Debug.WriteLine("Found period");
                }
                else if (file[i] == '?')
                {
                    //System.Diagnostics.Debug.WriteLine("Found question mark");
                }
                else if (file[i] == ',')
                {
                    //System.Diagnostics.Debug.WriteLine("Found comma");
                }
                else if (file[i] == ';')
                {
                    //System.Diagnostics.Debug.WriteLine("Found semicolon");
                }
                else if (file[i] == ':')
                {
                    //System.Diagnostics.Debug.WriteLine("Found colon");
                }
                else if (file[i] == '(')
                {
                    //System.Diagnostics.Debug.WriteLine("Found open parenthesis");
                }
                else if (file[i] == ')')
                {
                    //System.Diagnostics.Debug.WriteLine("Found close parenthesis");
                }
                else if (file[i] == '[')
                {
                    //System.Diagnostics.Debug.WriteLine("Found open bracket");
                }
                else if (file[i] == ']')
                {
                    //System.Diagnostics.Debug.WriteLine("Found close bracket");
                }
                else if (file[i] == '0' || file[i] == '1' || file[i] == '2' || file[i] == '3' || file[i] == '4' || file[i] == '5' || file[i] == '6'
                    || file[i] == '7' || file[i] == '8' || file[i] == '9')
                {
                    //System.Diagnostics.Debug.WriteLine("Found a number");
                }
                else if (file[i] == '<')
                {
                    while (file[i] != '>')
                    {
                        i++;
                    }
                }
                else if (file[i] == '"')
                {
                    //System.Diagnostics.Debug.WriteLine("Found quotation mark");
                }
                else if (file[i] == '#')
                {
                    //System.Diagnostics.Debug.WriteLine("Found pound symbol");
                }
                else if (file[i] == '–')
                {
                    //System.Diagnostics.Debug.WriteLine("Found hyphen");
                    cleanString += " ";
                }
                else if (file[i] == '~')
                {
                    //System.Diagnostics.Debug.WriteLine("Found tilde");
                }
                else if (file[i] == '/')
                {
                    //System.Diagnostics.Debug.WriteLine("Found forward slash");
                }
                else
                {
                    cleanString += file[i];
                }

            }
            while (cleanString.Contains("  "))
            {
                cleanString = cleanString.Replace("  ", " ");
            }
            cleanString = cleanString.Replace(Environment.NewLine, "");

            return cleanString.ToLower();
        }
    }
}
