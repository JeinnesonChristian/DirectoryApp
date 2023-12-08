using Microsoft.Maui.Graphics.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace DirectoryApp;

public partial class Register : ContentPage, INotifyPropertyChanged
{

    public Register()
    {
        InitializeComponent();
        Shell.Current.Title = "Register User";
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetBackButtonTitle(this, "Back");
        schoolProgramPicker.SelectedIndexChanged += OptionPicker_SelectedIndexChanged;
        BindingContext = this;

    }

    private Color _passwordBackgroundColor = Colors.LightGray;
    private Color _confirmPasswordBackgroundColor = Colors.LightGray;
    public Color PasswordBackgroundColor
    {
        get => _passwordBackgroundColor;
        set
        {
            if (_passwordBackgroundColor != value)
            {
                _passwordBackgroundColor = value;
                OnPropertyChanged(nameof(PasswordBackgroundColor));
            }
        }
    }
    public Color ConfirmPasswordBackgroundColor
    {
        get => _confirmPasswordBackgroundColor;
        set
        {
            if (_confirmPasswordBackgroundColor != value)
            {
                _confirmPasswordBackgroundColor = value;
                OnPropertyChanged(nameof(ConfirmPasswordBackgroundColor));
            }
        }
    }

    private void OnStudentIDTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string numericText = FilterNonNumeric(text);
        studentID.Text = numericText;
        ValidateForm();
    }
    private string FilterNonNumeric(string input)
    {
        return Regex.Replace(input, "[^0-9]", "");
    }

    private void OnMobileNoTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string numericText = FilterNonNumeric(text);
        mobileNo.Text = numericText;
        ValidateForm();
    }
   

    private void OnFirstNameChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string alphanumericText = FilterNonAlphanumeric(text);
        firstName.Text = alphanumericText;
        ValidateForm();
    }
    private void OnMiddleNameChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string alphanumericText = FilterNonAlphanumeric(text);
        middleName.Text = alphanumericText;
        ValidateForm();
    }
    private void OnLastNameChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string alphanumericText = FilterNonAlphanumeric(text);
        lastName.Text = alphanumericText;
        ValidateForm();
    }
    private string FilterNonAlphanumeric(string input)
    {
        return Regex.Replace(input, "[^a-zA-Z0-9]", "");
    }


    private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
    {
        string email = e.NewTextValue;
        bool isValid = IsEmailValid(email);
        ValidateForm();

        if (!isValid)
        {
            emailEntry.TextColor = Colors.Red;
        }
        else
        {
            emailEntry.TextColor = Colors.Black;
        }
    }
    private bool IsEmailValid(string email)
    {
        string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        return Regex.IsMatch(email, pattern);
    }


    private void OnEntryAlphaNumericTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string alphaNumericText = FilterNonAlphaNumeric(text);
        passwordEntry.Text = alphaNumericText;
        ValidatePasswords();
        ValidateForm();
    }
    private void OnEntryAlphaNumericTextChanged2(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        string alphaNumericText = FilterNonAlphaNumeric(text);
        confirmpasswordEntry.Text = alphaNumericText;
        ValidatePasswords();
        ValidateForm();
    }
    private string FilterNonAlphaNumeric(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z0-9]", "");
    }
    private void ValidatePasswords()
    {
        string password = passwordEntry.Text;
        string confirmPassword = confirmpasswordEntry.Text;
        

        if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            //validationMessageLabel.Text = "“Password” and “Confirm Password” should match";
            //validationMessageLabel.IsVisible = true;
            PasswordBackgroundColor = Colors.LightPink;
            ConfirmPasswordBackgroundColor = Colors.LightPink;
        }
        else if (password == confirmPassword)
        {
            //validationMessageLabel.IsVisible= false;
            PasswordBackgroundColor = Colors.LightGray;
            ConfirmPasswordBackgroundColor = Colors.LightGray;
        }
        else
        {
            //validationMessageLabel.Text= "“Password” and “Confirm Password” should match";
            //validationMessageLabel.IsVisible= true;
            PasswordBackgroundColor = Colors.LightPink;
            ConfirmPasswordBackgroundColor = Colors.LightPink;
        }
    }

    private void OptionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidateForm();
        int selectedIndex = schoolProgramPicker.SelectedIndex;
        if (selectedIndex != -1)
        {
            string selectedOption = schoolProgramPicker.Items[selectedIndex];
            selectedOptionLabel.Text = "Selected Option: " + selectedOption;
        }
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime selectedDate = e.NewDate;
        //DateTime correctDate = DateTime.Now;

        //if (selectedDate == correctDate)
        //{
            //datePicker.TextColor = Colors.Black;
        //}
        //else
        //{
            //datePicker.TextColor = Colors.Red;
        //}
        //selectedDateLabel.Text = "Selected Date" + selectedDate.ToString("D");
    }

    private async void NavigateToRegisterPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private void OnCityTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = city.Text;
        ValidateForm();
    }
    private void OnCityCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }

    private void OnResetButtonClicked(object sender, EventArgs e)
    {
        //clear textbox
        studentID.Text = string.Empty;
        firstName.Text = string.Empty;
        middleName.Text = string.Empty;
        lastName.Text = string.Empty;
        emailEntry.Text = string.Empty;
        passwordEntry.Text = string.Empty;
        confirmpasswordEntry.Text = string.Empty;
        mobileNo.Text = string.Empty;
        city.Text = string.Empty;
        //deselect radio buttons
        radio1.IsChecked = false;
        radio2.IsChecked = false;
        //dropdown reset
        schoolProgramPicker.SelectedIndex = 0;
        coursePicker.SelectedIndex = 0;
        yearLevelPicker.SelectedIndex = 0;
    }

    private async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        if(submitButton.IsEnabled)
        {
            var student = new Student
            {
                StudentID = studentID.Text,
                FirstName = firstName.Text,
                MiddleName = middleName.Text,
                LastName = lastName.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                ConfirmPassword = confirmpasswordEntry.Text,
                MobileNo = mobileNo.Text,
                City = city.Text,
                IsRadioSelected = radio1.IsChecked,
                IsRadio2Selected = radio2.IsChecked,
                SchoolProgram = schoolProgramPicker.SelectedItem as string,
                Course = coursePicker.SelectedItem as string,
                YearLevel = yearLevelPicker.SelectedItem as string
            };
            OnRegister();
            string enteredValues = $"Student ID: {student.StudentID}\n" +
                                   $"Full Name: {student.FirstName} {student.MiddleName} {student.LastName}\n" +
                                   $"Email: {student.Email}\n" +
                                   $"Mobile No: {student.MobileNo}\n" +
                                   $"City: {student.City}\n" +
                                   $"Gender: {(student.IsRadioSelected ? "Male" : "Female")}\n" +
                                   $"School Program: {student.SchoolProgram}\n" +
                                   $"Course: {student.Course}\n" +
                                   $"Year Level: {student.YearLevel}";

            await DisplayAlert("Submission Confirmation", $"Form Submitted & Student Registered!\n\n{enteredValues}", "OK");
        }
        
    }

    private void ValidateForm()
    {
        int nonEmptyCount = 0;
        
        if (!string.IsNullOrWhiteSpace(studentID.Text)) nonEmptyCount++; 
        if( !string.IsNullOrWhiteSpace(firstName.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(middleName.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(lastName.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(emailEntry.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(passwordEntry.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(confirmpasswordEntry.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(mobileNo.Text)) nonEmptyCount++;
        if( !string.IsNullOrWhiteSpace(city.Text)) nonEmptyCount++;
        if( radio1.IsChecked) nonEmptyCount++;
        if( radio2.IsChecked) nonEmptyCount++;
        if( schoolProgramPicker.SelectedIndex >= 0) nonEmptyCount++;
        if( coursePicker.SelectedIndex >= 0) nonEmptyCount++;
        if( yearLevelPicker.SelectedIndex >= 0) nonEmptyCount++;
       
        submitButton.IsEnabled = nonEmptyCount >=13;
    }
   

    //method Register()
    private void OnRegister()
    {
        var student = new Student
        {
            StudentID = studentID.Text,
            FirstName = firstName.Text,
            MiddleName = middleName.Text,
            LastName = lastName.Text,
            Email = emailEntry.Text,
            Password = passwordEntry.Text,
            ConfirmPassword = confirmpasswordEntry.Text,
            MobileNo = mobileNo.Text,
            City = city.Text,
            IsRadioSelected =radio1.IsChecked,
            IsRadio2Selected =radio2.IsChecked,
            SchoolProgram = schoolProgramPicker.SelectedItem as string,
            Course = coursePicker.SelectedItem as string,
            YearLevel = yearLevelPicker.SelectedItem as string
        };
    }

}