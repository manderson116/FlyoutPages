using System.Collections.ObjectModel;

namespace FlyoutPages
{
    public partial class AlcoholHelper : ContentPage
    {
        int drinkingAge = -1;

        public class Country
        {
            public string CountryName { get; set; }
            public int CountryDrinkingAge { get; set; }
        }

        ObservableCollection<Country> countries = new ObservableCollection<Country>();
        public ObservableCollection<Country> Countries { get { return countries; } }
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Country selectedCountry = ((Picker)sender).SelectedItem as Country;
            drinkingAge = selectedCountry.CountryDrinkingAge;
            Console.WriteLine(selectedCountry.CountryName);
        }
        public AlcoholHelper()
        {
            CurrentDate = DateTime.Today;
            InitializeComponent();
            countries.Add(new Country() { CountryName = "United States", CountryDrinkingAge = 21 });
            countries.Add(new Country() { CountryName = "Canada", CountryDrinkingAge = 19 });
            countries.Add(new Country() { CountryName = "United Kingdom", CountryDrinkingAge = 18 });
            countries.Add(new Country() { CountryName = "Germany", CountryDrinkingAge = 16 });
            countries.Add(new Country() { CountryName = "Mexico", CountryDrinkingAge = 18 });
            countries.Add(new Country() { CountryName = "Russia", CountryDrinkingAge = 18 });
            CountryPicker.ItemsSource = countries;
        }

        public DateTime CurrentDate { get; set; }

        private string getDrinkingText(double drinkDays)
        {
            double drinkYears = drinkDays / 365.2425;
            double drinkMonths = Math.Floor((drinkYears * 12) % 12);

            string timeText = "";

            // If >0 years, add years to display.
            if (Math.Floor(drinkYears) > 1)
                timeText += Math.Floor(drinkYears) + " years";
            else if (Math.Floor(drinkYears) == 1)
                timeText += Math.Floor(drinkYears) + " year";

            // If >0 years and >0 months in year, add "and" to display.
            if (Math.Floor(drinkYears) > 0 && drinkMonths > 0)
                timeText += " and ";

            // If >0 months in year, add months to display.
            if (drinkMonths > 1)
                timeText += drinkMonths + " months";
            else if (drinkMonths == 1)
                timeText += drinkMonths + " month";

            // If 0 years and 0 months, display days.
            if (Math.Floor(drinkYears) < 1 && drinkMonths < 1)
            {
                if (drinkDays > 1)
                    timeText += Math.Floor(drinkDays) + " days";
                else if (drinkDays == 1)
                    timeText += Math.Floor(drinkDays) + " day";
            }

            return timeText;
        }

        private void OnCalcClicked(object sender, EventArgs e)
        {
            if (drinkingAge < 0)
            {
                TimeLabel.Text = "Please select a country.";
                return;
            }

            double drinkDays = (EnterDOB.Date.AddYears(drinkingAge).Subtract(DateTime.Today)).Days;

            if (drinkDays > 0)
                TimeLabel.Text = $"You can start drinking on {(EnterDOB.Date.AddYears(drinkingAge)).ToShortDateString()}, {getDrinkingText(drinkDays)} from now.";
            else
                TimeLabel.Text = $"You could drink since {(EnterDOB.Date.AddYears(drinkingAge)).ToShortDateString()}!";

            SemanticScreenReader.Announce(TimeLabel.Text);
        }
    }
}