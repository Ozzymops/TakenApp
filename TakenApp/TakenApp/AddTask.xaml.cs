using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TakenApp.Models;

namespace TakenApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTask : ContentPage
	{
		public AddTask ()
		{
			InitializeComponent ();
		}

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Models.Sqlite sqlite = new Models.Sqlite();

            if (IntervalEntry.Text == null)
            {
                IntervalEntry.Text = "0";
            }

            if (DescriptionEntry.Text == null)
            {
                DescriptionEntry.Text = "";
            }

            // Checks
            if (NameEntry.Text == null || NameEntry.Text == "")
            {
                DisplayAlert("Fout!", "Vul a.u.b. een geldige naam in.", "OK");
                return;
            }

            Models.Task newTask = new Models.Task() {
                Name = NameEntry.Text,
                Description = DescriptionEntry.Text,
                Date = DatePicker.Date,
                Time = TimePicker.Time,
                Interval = Convert.ToInt32(IntervalEntry.Text.ToString().Trim())
            };

            bool status = sqlite.AddTask(newTask);

            // Toon status
            if (status)
            {
                DisplayAlert("Succes!", "Taak is opgeslagen.", "OK");
            }
            else
            {
                DisplayAlert("Fout!", "Er is iets fout gegaan.", "OK");
            }
        }
    }
}