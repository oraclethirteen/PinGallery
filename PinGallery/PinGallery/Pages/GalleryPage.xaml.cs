using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PinGallery.Models;

namespace PinGallery.Pages
{
    public partial class GalleryPage : ContentPage
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        Photo SelectedPhoto;

        public GalleryPage()
        {
            InitializeComponent();

            Photos.Add(new Photo("photo1", date: "2022-02-15", image: "photo1.jpg"));
            Photos.Add(new Photo("photo2", date: "2022-02-15", image: "photo2.jpg"));
            Photos.Add(new Photo("photo3", date: "2022-02-15", image: "photo3.jpg"));
            Photos.Add(new Photo("photo4", date: "2022-02-15", image: "photo4.jpg"));
            Photos.Add(new Photo("photo5", date: "2022-02-15", image: "photo5.jpg"));

            BindingContext = this;
        }

        private void photoList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedPhoto = (Photo)e.SelectedItem;
        }

        private async void OpenPhoto(object sender, EventArgs e)
        {
            if (SelectedPhoto == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите фото!", "OK");
                return;
            }
            await Navigation.PushAsync(new PhotoPage(SelectedPhoto));
        }

        private async void DeletePhoto(object sender, EventArgs e)
        {
            if (SelectedPhoto == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите фото!", "OK");
                return;
            }
            else
            {
                var deviceToRemove = deviceList.SelectedItem as Photo;
                if (deviceToRemove != null)
                {
                    bool deleteResult = await DisplayAlert(null, $"Вы уверены, что хотите удалить {deviceToRemove.Name}?", "Нет", "Да");

                    if (!deleteResult)
                    {
                        Photos.Remove(deviceToRemove);
                        SelectedPhoto = null;
                        return;
                    }
                }
            }
        }
    }
}