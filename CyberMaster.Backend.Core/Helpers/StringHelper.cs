using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberMaster.Backend.Core.Helpers
{
    public static class StringHelper
    {
        public static string Initial(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return name.Substring(0, 1);
        }

        public static string ToTitleCase(this string title)
        {
            //Get the culture property of the thread.
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //Create TextInfo object.
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(title.ToLower());
        }
    }
}
