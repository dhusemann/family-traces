namespace Family_Traces
{
    public class GenValidation
    {
        public static string GetNameWithDates(string surname, string firstname, string birthDate, string diedDate)
        {
            if (birthDate == "")
            {
                birthDate = "?";
            }

            if (diedDate == "")
            {
                diedDate = "?";
            }
            return surname + ", " + firstname + " (" + birthDate + " - " + diedDate + ")";
        }

        public static string GetSurname(string name)
        {
            string surname = "";
            if (name.Trim().LastIndexOf(" ") > 0)
            {
                surname = name.Trim().Substring(name.Trim().LastIndexOf(" ") + 1);
            }

            return surname;
        }

        public static string GetFirstname(string name)
        {
            string firstname = name;
            if (name.Trim().LastIndexOf(" ") > 0)
            {
                firstname = name.Trim().Substring(0, name.Trim().LastIndexOf(" "));
            }

            return firstname;
        }


    }
}
