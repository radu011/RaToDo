using RaToDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RaToDo.UserControls
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        Database database = new Database();
        //public Task()
        //{
        //    isDone = false;
        //    InitializeComponent();
        //}
        public Task(int _id, string _title, string _description, DateTime _date, string _typeOfTask, string _category, bool _isDone = false)
        {
            InitializeComponent();
            ID = _id;
            Title = _title;
            Description = _description;
            Deadline = _date;
            Date = Deadline.ToString("HH:mm dd-MMM");
            TypeOfTask = _typeOfTask;
            Category = _category;
            isDone = _isDone;

            if (isDone == true)
                modifyStateOfTask();

        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Task));

        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }


        public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(string), typeof(Task));


        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(Task));

        public DateTime Deadline;
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(Task));


        public string TypeOfTask
        {
            get { return (string)GetValue(TypeOfTaskProperty); }
            set { SetValue(TypeOfTaskProperty, value); }
        }

        public static readonly DependencyProperty TypeOfTaskProperty = DependencyProperty.Register("TypeOfTask", typeof(string), typeof(Task));


        public bool isDone { get; set; }
        public int ID { get; set; }

        private void modifyStateOfTask()
        {
            isDone = true;
            btnCheckIcon.Icon = FontAwesome.Sharp.IconChar.CheckCircle;
            this.Opacity = 0.5;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (isDone == true)
            {
                isDone = false;
                btnCheckIcon.Icon = FontAwesome.Sharp.IconChar.Circle;
                this.Opacity = 1;
            }
            else
            {
                // if task is done
                modifyStateOfTask();
            }

            // actualizeaza in baza de date
            database.UpdateTask(ID, Deadline, Title, Description, Category, isDone);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            borderMain.Visibility = Visibility.Collapsed;
            // And delete it from database
            database.DeleteTask(ID);
        }

        private struct BeforeEdit
        {
            public string editTilu;
            public string editDescriere;
            public string editCategorie;
        }

        private BeforeEdit beforeEdit = new BeforeEdit();
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditImage.Icon == FontAwesome.Sharp.IconChar.Edit)
            {
                beforeEdit.editTilu = Title;
                beforeEdit.editDescriere = Description;
                beforeEdit.editCategorie = Category;

                txtblockTitle.IsReadOnly = false;
                txtblockTitle.BorderThickness = new Thickness(0, 0, 0, 1);

                txtblockDescription.IsReadOnly = false;
                txtblockDescription.BorderThickness = new Thickness(0, 0, 0, 1);

                txtblockCategory.IsReadOnly = false;
                txtblockCategory.BorderThickness = new Thickness(0, 0, 0, 1);

                btnEditImage.Icon = FontAwesome.Sharp.IconChar.Check;

                return;
            }

            if (btnEditImage.Icon == FontAwesome.Sharp.IconChar.Check)
            {
                txtblockTitle.IsReadOnly = true;
                txtblockTitle.BorderThickness = new Thickness(0);

                txtblockDescription.IsReadOnly = true;
                txtblockDescription.BorderThickness = new Thickness(0);

                txtblockCategory.IsReadOnly = true;
                txtblockCategory.BorderThickness = new Thickness(0);

                btnEditImage.Icon = FontAwesome.Sharp.IconChar.Edit;

                // submit task changes to database
                if(database.UpdateTask(ID, Deadline, Title, Description, Category, isDone) == false)
                {
                    string messageBoxText = $"Do you want to create category '{Category}'?";
                    string caption = "Category";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                    if (result == MessageBoxResult.Yes) 
                    {
                        // add new category in database
                        database.AddCategory(database.getUserIDbyTaskID(ID), Category);
                        return;
                    }

                    Title = beforeEdit.editTilu;
                    Description = beforeEdit.editDescriere;
                    Category = beforeEdit.editCategorie;

                    beforeEdit.editTilu = null;
                    beforeEdit.editDescriere = null;
                    beforeEdit.editCategorie = null;
                }

                return;
            }
        }
    }
}
