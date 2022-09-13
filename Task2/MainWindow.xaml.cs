using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _hashCode;
        private bool _cancelChanges;
        public MainWindow()
        {
            InitializeComponent();

            _cancelChanges = false;
            var user = new User("Dkit", "dkit@test.ru", "DkitGit");
            _hashCode = user.GetHashCode();
            DataContext = user;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(DataContext.GetHashCode() != _hashCode && !_cancelChanges)
            {
                MDSnackbarUnsavedChanges.IsActive = true;
                e.Cancel = true;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext.GetHashCode() != _hashCode && !_cancelChanges)
            {
                MDSnackbarUnsavedChanges.IsActive = true;
                MDSnackbarMessage.Content = "Данные обновлены";
                MDSnackbarMessage.ActionContent = "OK";
            }
        }

        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            MDSnackbarUnsavedChanges.IsActive = false;
            _cancelChanges = true;
            Close();
        }
    }
}
