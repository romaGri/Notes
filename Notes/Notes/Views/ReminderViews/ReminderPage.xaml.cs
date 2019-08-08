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
    public partial class RemainderPage : ContentPage
    {
        public RemainderPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
         //   ListView.ItemsSource = await App.Database.GetReminderAsync();
        }

        async void OnReminderAddedClicked(object sennder, EventArgs e)
        {
            await Navigation.PushAsync(new ReminderEntryPage
            {
                BindingContext = new Reminder()
            });
        }
    
      
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ReminderEntryPage
                {
                    BindingContext = e.SelectedItem as Reminder
                });
            }
        }
    }
}