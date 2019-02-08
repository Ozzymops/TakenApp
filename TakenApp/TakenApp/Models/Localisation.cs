using System;
using System.Collections.Generic;
using System.Text;

namespace TakenApp.Models
{
    public enum Language { Nederlands, English };

    public class Localisation
    {
        public string TranslateString(Language l, string s)
        {
            // Nederlands
            if (l == Language.Nederlands)
            {
                // Dagen
                switch(s)
                {
                    case "Monday":
                        return "Maandag";

                    case "Tuesday":
                        return "Dinsdag";

                    case "Wednesday":
                        return "Woensdag";

                    case "Thursday":
                        return "Donderdag";

                    case "Friday":
                        return "Vrijdag";

                    case "Saturday":
                        return "Zaterdag";

                    case "Sunday":
                        return "Zondag";
                }
            }
            else
            {
                return s;
            }

            // Als niks gematchet kan worden...
            return "";
        }
    }
}
