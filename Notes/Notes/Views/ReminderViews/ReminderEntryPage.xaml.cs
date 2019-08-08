using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views.ReminderViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderEntryPage : ContentPage
    {
        Label label;
        DatePicker datePicker;
        TimePicker timePicker;
        public ReminderEntryPage()
        {
            InitializeComponent();

            label = new Label { Text = "choose date" };
            datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddMonths(24),
                MinimumDate = DateTime.Now
            };
            datePicker.DateSelected += datePicker_DateSelected;
            StackLayout stack = new StackLayout { Children = { label, datePicker } };
            this.Content = stack;
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var note = (Reminder)BindingContext;
            note.GetDate = DateTime.UtcNow;
            await App.Database.SaveItem(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");
            var note = (Reminder)BindingContext;
            await App.Database.DeleteAsync(note);
            await Navigation.PopAsync();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            label.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}