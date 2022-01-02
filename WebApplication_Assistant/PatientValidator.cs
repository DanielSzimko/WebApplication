using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication_Assistant
{
    public class PatientValidator
    {
        public bool NameTextBoxValidation(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return false;
            }
            return true;
        }

        public bool TAJNumberTextBoxValidation(string tajnumber)
        {

            Regex rg = new Regex("([0-9]{3} [0-9]{3} [0-9]{3}$)");

            if (!rg.IsMatch(tajnumber))
            {
                return false;
            }

            return true;
        }

        public bool ComplaintsTextBoxValidation(string complaints)
        {

            if (string.IsNullOrEmpty(complaints))
            {
                return false;
            }

            return true;
        }
    }
}
