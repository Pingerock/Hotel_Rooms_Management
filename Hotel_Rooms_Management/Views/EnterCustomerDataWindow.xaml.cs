using System.Windows;


namespace Hotel_Rooms_Management.Views
{
    /// <summary>
    /// Логика взаимодействия для EnterCustomerDataWindow.xaml
    /// </summary>
    public partial class EnterCustomerDataWindow : Window
    {
        public EnterCustomerDataWindow()
        {
            InitializeComponent();
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        public string FIO
        {
            get { return nameBox.Text; }
        }
        public string Phone
        {
            get { return phoneBox.Text; }
        }
        public string Passport
        {
            get { return passportBox.Text; }
        }
    }
}
