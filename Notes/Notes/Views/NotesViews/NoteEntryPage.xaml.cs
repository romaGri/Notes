using Notes.Models;
using System;

using Xamarin.Forms;

namespace Notes.Views.NotesViews

{

    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveItem(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");
            var note = (Note)BindingContext;
            await App.Database.DeleteAsync(note);
            await Navigation.PopAsync();
        }
    }
}