namespace ContactDemoXam.Models
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => (FirstName + " " + LastName).Trim();

        public string PictureUrl { get; set; }

        public string Picture { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string DisplayName
        {
            get
            {
                var display = "";

                if (!string.IsNullOrEmpty(FullName.Trim()))
                    display = FullName;
                else if (!string.IsNullOrEmpty(Company))
                    display = Company;

                return display;
            }
        }
    }
}
