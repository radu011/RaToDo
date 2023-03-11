using System;
using RaToDo.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using RaToDo.UserControls;
using FontAwesome.Sharp;
using System.Threading;
using MaterialDesignThemes.Wpf;
using Syncfusion.Windows.Shared;

namespace RaToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database database = new Database();
        public string Username { get; set; }

        public MainWindow(string _username)
        {
            InitializeComponent();

            Username = _username;
            textBlockUsername.Text = Username;

            radioButtonToday.IsChecked = true;
            radioButtonToday_Click(this, null);

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            initializeCategories();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void buttonMoreForUser_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextM = buttonMoreForUser.ContextMenu;
            contextM.PlacementTarget = buttonMoreForUser;
            contextM.IsOpen = true;
        }

        private void miLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen ls = new LoginScreen();
            ls.Show();
            this.Close();
        }

        private void miChangeProfileImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonToday_Click(object sender, RoutedEventArgs e)
        {
            iconPageName.Icon = IconRadioButtonToday.Icon;
            textBlockPageName.Text = TextBlockRadioButtonToday.Text;

            borderStatistics.Visibility = Visibility.Collapsed;
            spContentView.Visibility = Visibility.Visible;
            spContentView.Children.Clear();

            var taskList = database.getTasks(Username);

            foreach (var task in taskList)
            {
                if (task.Deadline.Date != DateTime.Today)
                    continue;

                string typeOfTask = database.getTypeOfTask(task.IDTask);
                string categorie = database.getTaskCategory(task.IDTask);

                spContentView.Children.Add(new UserControls.Task(task.IDTask, task.Titlu, task.Descriere, task.Deadline, typeOfTask, categorie, task.Stare));
            }
        }

        private void radioButtonThisWeek_Click(object sender, RoutedEventArgs e)
        {
            iconPageName.Icon = IconRadioButtonThisWeek.Icon;
            textBlockPageName.Text = TextBlockRadioButtonThisWeek.Text;

            borderStatistics.Visibility = Visibility.Collapsed;
            spContentView.Visibility = Visibility.Visible;
            spContentView.Children.Clear();

            var taskList = database.getTasks(Username);

            DateTime currentDateTime = DateTime.Now;
            DateTime startOfWeek = currentDateTime.Date.AddDays(-(int)currentDateTime.DayOfWeek + 1);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            foreach (var task in taskList)
            {
                if (!(task.Deadline >= startOfWeek && task.Deadline <= endOfWeek))
                    continue;

                string typeOfTask = database.getTypeOfTask(task.IDTask);
                string categorie = database.getTaskCategory(task.IDTask);

                spContentView.Children.Add(new UserControls.Task(task.IDTask, task.Titlu, task.Descriere, task.Deadline, typeOfTask, categorie, task.Stare));
            }
        }

        private void radioButtonTasks_Click(object sender, RoutedEventArgs e)
        {
            iconPageName.Icon = IconRadioButtonTasks.Icon;
            textBlockPageName.Text = textBlockRadioButtonTasks.Text;

            borderStatistics.Visibility = Visibility.Collapsed;
            spContentView.Visibility = Visibility.Visible;
            spContentView.Children.Clear();

            var taskList = database.getTasks(Username);
            int typeTaskId = database.getTaskTypeByTypeName("Task");

            foreach (var task in taskList)
            {
                if (task.IDTipTask != typeTaskId)
                    continue;

                string typeOfTask = database.getTypeOfTask(task.IDTask);
                string categorie = database.getTaskCategory(task.IDTask);

                spContentView.Children.Add(new UserControls.Task(task.IDTask, task.Titlu, task.Descriere, task.Deadline, typeOfTask, categorie, task.Stare));
            }
        }

        private void radioButtonMeetings_Click(object sender, RoutedEventArgs e)
        {
            iconPageName.Icon = IconRadioButtonMeetings.Icon;
            textBlockPageName.Text = TextBlockRadioButtonMeetings.Text;

            borderStatistics.Visibility = Visibility.Collapsed;
            spContentView.Visibility = Visibility.Visible;
            spContentView.Children.Clear();

            var taskList = database.getTasks(Username);
            int typeTaskId = database.getTaskTypeByTypeName("Meeting");

            foreach (var task in taskList)
            {
                if (task.IDTipTask != typeTaskId)
                    continue;

                string typeOfTask = database.getTypeOfTask(task.IDTask);
                string categorie = database.getTaskCategory(task.IDTask);

                spContentView.Children.Add(new UserControls.Task(task.IDTask, task.Titlu, task.Descriere, task.Deadline, typeOfTask, categorie, task.Stare));
            }
        }

        private void radioButtonStatistics_Click(object sender, RoutedEventArgs e)
        {
            textBlockPageName.Text = TextBlockRadioButtonStatistics.Text;
            iconPageName.Icon = IconRadioButtonStatistics.Icon;

            spContentView.Children.Clear();
            spContentView.Visibility = Visibility.Collapsed;
            borderStatistics.Visibility = Visibility.Visible;
        
            // continua cu statisticile
        }

        private void initializeCategories()
        {
            radioButtonCategory1.Visibility = Visibility.Collapsed;
            radioButtonCategory2.Visibility = Visibility.Collapsed;
            radioButtonCategory3.Visibility = Visibility.Collapsed;
            radioButtonCategory4.Visibility = Visibility.Collapsed;

            List<string> list = database.getCategories(Username);

            if (list.Count == 0)
                return;

            radioButtonTextBlockCategory1.Text = list[0];
            radioButtonCategory1.Visibility = Visibility.Visible;
            if (list.Count == 1)
                return;

            radioButtonTextBlockCategory2.Text = list[1];
            radioButtonCategory2.Visibility = Visibility.Visible;
            if (list.Count == 2)
                return;

            radioButtonTextBlockCategory3.Text = list[2];
            radioButtonCategory3.Visibility = Visibility.Visible;
            if (list.Count == 3)
                return;

            radioButtonTextBlockCategory4.Text = list[3];
            radioButtonCategory4.Visibility = Visibility.Visible;
        }

        private string getCategoryNameRadioButtonCheck()
        {
            if (radioButtonCategory1.IsChecked == true)
                return radioButtonTextBlockCategory1.Text;

            if (radioButtonCategory2.IsChecked == true)
                return radioButtonTextBlockCategory2.Text;

            if (radioButtonCategory3.IsChecked == true)
                return radioButtonTextBlockCategory3.Text;

            if (radioButtonCategory4.IsChecked == true)
                return radioButtonTextBlockCategory4.Text;

            return null;
        }

        private void setHeaderWhenCategoryClicked()
        {
            if(radioButtonCategory1.IsChecked == true)
            {
                iconPageName.Icon = IconRadioButtonCategory1.Icon;
                textBlockPageName.Text = radioButtonTextBlockCategory1.Text;
            }
            if(radioButtonCategory2.IsChecked == true)
            {
                iconPageName.Icon = IconRadioButtonCategory2.Icon;
                textBlockPageName.Text = radioButtonTextBlockCategory2.Text;
            }
            if(radioButtonCategory3.IsChecked == true)
            {
                iconPageName.Icon = IconRadioButtonCategory3.Icon;
                textBlockPageName.Text = radioButtonTextBlockCategory3.Text;
            }
            if(radioButtonCategory4.IsChecked == true)
            {
                iconPageName.Icon = IconRadioButtonCategory4.Icon;
                textBlockPageName.Text = radioButtonTextBlockCategory4.Text;
            }
        }

        private void radioButtonCategory_Click(object sender, RoutedEventArgs e)
        {
            setHeaderWhenCategoryClicked();

            borderStatistics.Visibility = Visibility.Collapsed;
            spContentView.Visibility = Visibility.Visible;
            spContentView.Children.Clear();

            var taskList = database.getTasks(Username);
            var categoryName = getCategoryNameRadioButtonCheck();
            if (categoryName == null)
                return;
            var categoryID = database.getCategoryIdByCategoryName(categoryName);

            foreach (var task in taskList)
            {
                if (categoryID != task.IDCategorie)
                    continue;

                string typeOfTask = database.getTypeOfTask(task.IDTask);
                string categorie = database.getTaskCategory(task.IDTask);

                spContentView.Children.Add(new UserControls.Task(task.IDTask, task.Titlu, task.Descriere, task.Deadline, typeOfTask, categorie, task.Stare));
            }

        }

        private void btnChooseTask_Click(object sender, RoutedEventArgs e)
        {
            stackPanelChooseWhatToAdd.Visibility = Visibility.Collapsed;
            stackPanelAddTask.Visibility = Visibility.Visible;

            List<string> listTaskType = database.getTypes();
            foreach (var el in listTaskType)
                comboBoxAddTaskType.Items.Add(el);

            List<string> listCategories = database.getCategories(Username);
            foreach (var el in listCategories)
                comboBoxAddTaskCategory.Items.Add(el);
        }

        private void btnChooseCategory_Click(object sender, RoutedEventArgs e)
        {
            stackPanelChooseWhatToAdd.Visibility = Visibility.Collapsed;
            stackPanelAddCategory.Visibility = Visibility.Visible;

            comboBoxAddCat.Items.Clear();

            List<string> categ = database.getCategories(Username);
            foreach(var cat in categ)
            {
                comboBoxAddCat.Items.Add(cat);
            }
        }

        private void btnChooseAddTask_Click(object sender, RoutedEventArgs e)
        {
            stackPanelAddCategory.Visibility = Visibility.Collapsed;
            stackPanelAddTask.Visibility = Visibility.Collapsed;
            stackPanelChooseWhatToAdd.Visibility = Visibility.Visible;

            comboBoxAddTaskType.Items.Clear();
            comboBoxAddTaskCategory.Items.Clear();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            // preia datele si adauga in baza de date
            // verificari prealabile
            if (comboBoxAddTaskCategory.Text.Length == 0 || textboxAddTaskName.Text.Length == 0 ||
                textboxAddTaskDescription.Text.Length == 0 || comboBoxAddTaskType.Text.Length == 0 ||
                datePickerAddTaskDate.Text.Length == 0 || timePickerAddTaskTime.Text.Length == 0)
            {
                AddTaskWarning.Text = "Don't let empty boxes!";
                AddTaskWarning.Foreground = Brushes.Red;
                AddTaskWarning.Visibility = Visibility.Visible;
                return;
            }

            // preia data + timpul, adauga timpul la data
            DateTime deadline = DateTime.Parse(datePickerAddTaskDate.Text);
            TimeSpan time = TimeSpan.Parse( timePickerAddTaskTime.Text);
            deadline = deadline.AddHours(time.Hours);
            deadline = deadline.AddMinutes(time.Minutes);

            bool remainder = false;
            if (listBoxAddTaskRemainderOn.IsSelected == true && listBoxAddTaskRemainderOff.IsSelected == false)
                remainder = true;
            if (listBoxAddTaskRemainderOn.IsSelected == false && listBoxAddTaskRemainderOff.IsSelected == true)
                remainder = false;

            database.AddTask(comboBoxAddTaskType.Text, comboBoxAddTaskCategory.Text, Username,
                textboxAddTaskName.Text, textboxAddTaskDescription.Text, deadline, false, remainder);

            btnAddTaskClearBoxes_Click(null, null);

            AddTaskWarning.Foreground = Brushes.Green;
            AddTaskWarning.Visibility = Visibility.Visible;
            AddTaskWarning.Text = "Task added successfully!";

            refreshTaskView();
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            // textboxAddCategoryText
            // preia datele si adauga in baza de date
            database.AddCategory(Username, comboBoxAddCat.Text);
            initializeCategories();
            comboBoxAddCat.Text = string.Empty;
        }

        private void refreshTaskView()
        {
            spContentView.Visibility = Visibility.Visible;

            if (radioButtonCategory1.IsChecked == true ||
                    radioButtonCategory2.IsChecked == true ||
                    radioButtonCategory3.IsChecked == true ||
                    radioButtonCategory4.IsChecked == true)
                radioButtonCategory_Click(null, null);

            if (radioButtonTasks.IsChecked == true)
                radioButtonTasks_Click(null, null);

            if (radioButtonMeetings.IsChecked == true)
                radioButtonMeetings_Click(null, null);

            if (radioButtonStatistics.IsChecked == true)
                radioButtonStatistics_Click(null, null);

            if (radioButtonToday.IsChecked == true)
                radioButtonToday_Click(null, null);

            if (radioButtonThisWeek.IsChecked == true)
                radioButtonThisWeek_Click(null, null);
        }

        private void btnAddTaskClearBoxes_Click(object sender, RoutedEventArgs e)
        {
            textboxAddTaskName.Text = string.Empty;
            textboxAddTaskDescription.Text = string.Empty;
            comboBoxAddTaskCategory.Text = string.Empty;
            comboBoxAddTaskType.Text = string.Empty;
            datePickerAddTaskDate.Text = string.Empty;
            timePickerAddTaskTime.Text = string.Empty;

            AddTaskWarning.Visibility = Visibility.Collapsed;
            
            listBoxAddTaskRemainderOff.IsSelected = true;
            listBoxAddTaskRemainderOn.IsSelected = false;
        }

        private void AddTaskCloseDialog_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWarning.Visibility = Visibility.Collapsed;
        }

        private void btnNotificationModeChange_Click(object sender, RoutedEventArgs e)
        {
            if(btnNotificationModeChange.Foreground == Brushes.Red)
            {
                database.changeRemainder(Username, true);
                btnNotificationModeChange.Foreground = Brushes.Green;
                return;
            }
            database.changeRemainder(Username, false);
            btnNotificationModeChange.Foreground = Brushes.Red;
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if(database.deleteCategory(Username, comboBoxAddCat.Text) == false)
            {
                textBlockErrorDeleteCategory.Visibility = Visibility.Visible;
                return;
            }

            comboBoxAddCat.Items.Remove(comboBoxAddCat.Text);

            initializeCategories();
        }

        private void comboBoxAddCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockErrorDeleteCategory.Visibility = Visibility.Collapsed;
        }
    }
}
