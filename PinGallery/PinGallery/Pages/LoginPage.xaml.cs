using PinGallery.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PinGallery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static int loginCouner = 0;
        public const string LABEL_TEXT = "Установите четырёхзначный пин-код приложения:";
        public const string BUTTON_TEXT = "Сохранить";


        public string Login { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        User user = new User();

        private async void enterButton_Clicked(object sender, EventArgs e)
        {
            Login = pinForEntry.Text;

            if (loginCouner > 0)
            {
                loginButton.Text = "Введите ваш пин-код:";
                enterButton.Text = "Войти";
            }

            if (String.IsNullOrEmpty(Login))
            {
                await DisplayAlert("Ошибка", $"Поле ввода не должно быть пустым!", "OK");
                return;
            }
            else if (Login.Length != 4)
            {
                await DisplayAlert("Ошибка", $"Пароль должен содержать 4 символа!", "OK");
                return;
            }
            else if (user.Password == Login && loginCouner > 0)
            {
                await Navigation.PushAsync(new GalleryPage());
            }
            else if (loginCouner == 0)
            {
                await DisplayAlert(null, $"Ваш пароль сохранён!", "OK");
                await Navigation.PushAsync(new GalleryPage());
            }
            else
            {
                await DisplayAlert("Ошибка", $"Неверный пароль!", "OK");
                return;
            }

            loginCouner += 1;
        }
    }
}