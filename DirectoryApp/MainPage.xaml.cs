
using System.Windows.Input;

namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private const string ValidUsername = "user";
        private const string ValidPassword = "password";
        public ICommand TapCommand => new Command(NavigateRegisterPage);

        private async void NavigateRegisterPage(object obj)
        {
            await Navigation.PushAsync(new Register());
        }

        public MainPage()
        {
            InitializeComponent();
            Shell.Current.Title = "Window Title";
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            string myText = usernameEntry.Text;
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = usernameEntry.Text;
            string enteredPassword = passwordEntry.Text;

            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                LoginMessage.TextColor = Colors.Red;
                LoginMessage.Text = "Username and/or Password should not be empty. Please try again.";
            }
            else if (enteredUsername == ValidUsername && enteredPassword == ValidPassword)
            {
                LoginMessage.TextColor = Colors.LimeGreen;
                LoginMessage.Text = "Login Successful!";
            }
            else
            {
                LoginMessage.TextColor = Colors.Red;
                LoginMessage.Text = "Username and/or Password should not be empty. Please try again.";
            }
        } 
    }
}