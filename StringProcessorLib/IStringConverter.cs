using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessorLib
{
    public interface IStringConverter
    {
        List<string> ConvertStrings(List<string> inputStrings);
    }
}