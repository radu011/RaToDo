using RaToDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RaToDo
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        Database database = new Database();
        public LoginScreen()
        {
            InitializeComponent();
            inputUserNameData.Focus();
        }

        // Window controls
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Reset password
        private void btnResetMail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            loadResetPasswordScreen();
        }

        // Register
        private void btnRegister_MouseDown(object sender, MouseButtonEventArgs e)
        {
            loadRegisterScreen();
        }

        // Back to login button
        private void btnBackToLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            loadLoginScreen();
        }

        // Change window configuration
        // Login
        private void loadLoginScreen()
        {
            labelWindowTitle.Content = "Log in";

            spRegister.Visibility = Visibility.Visible;
            spResetPassword.Visibility = Visibility.Visible;

            btnSubmit.Content = "LOG IN";
            btnSubmit.Margin = new Thickness(0, 40, 0, 0);

            textblockInputPassword.Text = "Password";

            InputPasswordBoxIcon.ImageSource = new BitmapImage(new Uri("../../images/key-icon.png", UriKind.Relative));

            passboxInputPassword.Password = "";

            spBackToLogin.Visibility = Visibility.Collapsed;

            spRegisterData.Visibility = Visibility.Collapsed;
            spMainBody.Margin = new Thickness(0, 50, 0, 0);
            imageLogo.Margin = new Thickness(0, 0, 0, 30);
        }
        // Reset mail
        private void loadResetPasswordScreen()
        {
            labelWindowTitle.Content = "Reset password";

            spRegister.Visibility = Visibility.Collapsed;
            spResetPassword.Visibility = Visibility.Collapsed;

            btnSubmit.Content = "Send mail";

            textblockInputPassword.Text = "Email";

            InputPasswordBoxIcon.ImageSource = new BitmapImage(new Uri("../../images/email-icon.png", UriKind.Relative));

            passboxInputPassword.Password = "";

            spBackToLogin.Visibility = Visibility.Visible;
        }
        // Register
        private void loadRegisterScreen()
        {
            labelWindowTitle.Content = "Register";

            spRegister.Visibility = Visibility.Collapsed;
            spResetPassword.Visibility = Visibility.Collapsed;

            btnSubmit.Content = "Register";
            btnSubmit.Margin = new Thickness(0, 15, 0, 0);

            passboxInputPassword.Password = "";
            passwordValidation.Text = "";

            spBackToLogin.Visibility = Visibility.Visible;

            spRegisterData.Visibility = Visibility.Visible;
            spMainBody.Margin = new Thickness(0, 0, 0, 0);
            imageLogo.Margin = new Thickness(0, 0, 0, 10);

            tbWarning.Visibility = Visibility.Collapsed;
        }

        // Submit data
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSubmit.Content.ToString() == "Send mail")
            {
                resetPassword();
                return;
            }

            if (btnSubmit.Content.ToString() == "LOG IN")
            {
                login();
                return;
            }

            if (btnSubmit.Content.ToString() == "Register")
            {
                register();
                return;
            }
        }

        // Reset password function
        private void resetPassword()
        {
            if (database.VerifyPasswordReset(inputUserNameData.Text, inputEmail.Text))
            {
                // trimite email
                return;
            }
            // afiseaza eroare
        }

        // Register function
        private void register()
        {
            if (database.VerifyUserForRegister(inputUserNameData.Text) == true)
            {
                database.RegisterUser(1, inputFirstNameData.Text, inputSecondNameData.Text, inputUserNameData.Text,
                    passboxInputPassword.Password.ToString(), inputEmail.Text);
                loadLoginScreen();
                inputFirstNameData.Text = string.Empty;
                inputSecondNameData.Text = string.Empty;
                inputEmail.Text = string.Empty;
                passboxInputPasswordAgain.Password =string.Empty;
            }
            else
            {
                string messageBoxText = "The username is already used, try another one.";
                string caption = "Register error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        // Log in function
        private void login()
        {
            if (database.VerifyUserForLogin(inputUserNameData.Text, passboxInputPassword.Password.ToString()) == true)
            {
                MainWindow win = new MainWindow(inputUserNameData.Text);
                win.Show();
                this.Close();
            }
            else
            {
                passwordValidationForLogin.Visibility = Visibility.Visible;
            }
        }

        // Verify password boxes to match
        private void passboxInputPasswordAgain_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordValidation.Visibility = Visibility.Visible;

            if (passboxInputPassword.Password.ToString() != passboxInputPasswordAgain.Password.ToString())
            {
                passwordValidation.Text = "Passwords doesn't match!";
                passwordValidation.Foreground = Brushes.Red;
                return;
            }
            else
            {
                if (passwordValidation.Text.Length < 8)
                    return;
                passwordValidation.Text = "Good";
                passwordValidation.Foreground = Brushes.Green;
            }

            // apeleaza logica :)
        }

        private void passboxInputPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordValidation.Visibility = Visibility.Visible;

            if (passboxInputPassword.Password.ToString().Length < 8)
            {
                passwordValidation.Text = "Minimum password length is 8!";
                passwordValidation.Foreground = Brushes.Red;
                return;
            }
            else
            {
                string symbols = " ~`!@#$%^&*()_-+={[}]|:;<,>.?/";
                bool hasUppercase = false;
                bool hasDigit = false;
                bool hasSymbol = false;
                foreach (char c in passboxInputPassword.Password.ToCharArray())
                {
                    if (char.IsDigit(c))
                        hasDigit = true;

                    if (char.IsUpper(c))
                        hasUppercase = true;

                    if (symbols.IndexOf(c) != -1)
                        hasSymbol = true;
                }

                if (hasUppercase == false)
                {
                    passwordValidation.Text = "Use at least one upper case character!";
                    passwordValidation.Foreground = Brushes.Red;
                    return;
                }

                if (hasDigit == false)
                {
                    passwordValidation.Text = "Use at least one digit character!";
                    passwordValidation.Foreground = Brushes.Red;
                    return;
                }

                if (hasSymbol == false)
                {
                    passwordValidation.Text = $"Use at least one symbol! ({symbols})";
                    passwordValidation.Foreground = Brushes.Red;
                    return;
                }
            }
            passwordValidation.Text = "Good security!";
            passwordValidation.Foreground = Brushes.Green;
        }

        private void passboxInputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSubmit_Click(sender, e);
        }
    }
}
