using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TakenApp.Models;

namespace TakenApp
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Tijdelijke takenlijst
        /// </summary>
        private List<Models.Task> taskList;

        /// <summary>
        /// Sqlite instantie
        /// </summary>
        private Sqlite sqlite = new Models.Sqlite();

        /// <summary>
        /// Lokalisatie file
        /// </summary>
        private Localisation loc = new Models.Localisation();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetList();
        }

        /// <summary>
        /// Stel lijsten in voor het tonen van Tasks.
        /// </summary>
        private void SetList()
        {
            taskList = sqlite.GetTasks();
            TaskListView.ItemsSource = taskList;
            FooterLabel.Text = taskList.Count.ToString() + " taken voor vandaag, " + loc.TranslateString(Language.Nederlands, DateTime.Now.DayOfWeek.ToString());
        }

        private void DebugList()
        {
            taskList = new List<Models.Task>();
            for (int i = 0; i < 10; i++)
            {
                taskList.Add(new Models.Task {
                    Name = DateTime.Now.ToString("hh:mm") + " | Taak " + i.ToString(),
                    Description = "Taak nummer " + i.ToString() + " op " + loc.TranslateString(Language.Nederlands, DateTime.Now.Date.ToString())
                });
            }

            TaskListView.ItemsSource = taskList;
            FooterLabel.Text = taskList.Count.ToString() + " taken voor vandaag, " + loc.TranslateString(Language.Nederlands, DateTime.Now.DayOfWeek.ToString());
        }

        /// <summary>
        /// Voeg een Task toe aan de lijst en sla deze op in een lokale database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask() { Title = "Taak toevoegen" });
        }

        /// <summary>
        /// Verwijder een geselecteerde Task uit de lijst en haal deze ook uit de lokale database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Sqlite sqlite = new Sqlite();
            sqlite.RemoveTask((Models.Task)TaskListView.SelectedItem);
            SetList();
            DisplayAlert("Succes!", "Taak verwijderd.", "OK");
        }
    }
}
