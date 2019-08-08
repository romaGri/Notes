using Notes.Models;
using Notes.Views.ReminderViews;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views.NotesViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }
        async void OnReminderAddedClicked(object sender, EventArgs e)
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
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }

}