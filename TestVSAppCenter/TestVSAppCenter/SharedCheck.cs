using System;
using System.Linq;
using System.Collections.Generic;

namespace TestVSAppCenter
{
    public class SharedCheck
    {

        public List<string> ExtractTokens(string jumboString)
        {

            if (string.IsNullOrEmpty(jumboString) == true)
                return null;

            var tokensArray = jumboString.Split(new string[] { "-", "/", "."}, StringSplitOptions.RemoveEmptyEntries);
            return tokensArray.ToList();

        }


    }
}
