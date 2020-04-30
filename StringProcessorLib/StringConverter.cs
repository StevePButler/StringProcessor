#region Using Statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace StringProcessorLib
{
    public class StringConverter : IStringConverter
    {
        #region Public Methods

        public List<string> ConvertStrings(List<string> inputStrings)
        {
            List<string> outputStrings = new List<string>();

            // Check if input list is null or empty.
            if (inputStrings == null || inputStrings.Count == 0) return outputStrings;

            foreach (string a in inputStrings)
            {
                // Check if string is null;
                if (String.IsNullOrEmpty(a)) continue;
                
                // Remove spaces.
                string b = a.Trim().Replace(" ", String.Empty);

                // Remove underscores.
                string c = b.Trim().Replace("_", String.Empty);

                // Remove 4's
                string d = c.Replace("4", String.Empty);

                // Check if there are any characters remaining.
                if (d.Length == 0) continue;

                // Replace dollar signs.
                string e = d.Replace("$", "£");

                // Remove contiguous duplicates.
                char? currentChar = null;
                char? previousChar = null;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < e.Length; i++)
                {
                    currentChar = e[i];

                    if (i == 0) 
                        sb.Append(currentChar);
                    else
                        if (currentChar != previousChar) sb.Append(currentChar);

                    previousChar = currentChar;
                }

                string f = sb.ToString();

                // Add converted string to output list (truncate to 15 chars if necessary).
                if (f.Length > 15)
                    outputStrings.Add(f.Substring(0, 15));
                else
                    outputStrings.Add(f);
            }

            return outputStrings;
        }

        #endregion
    }
}