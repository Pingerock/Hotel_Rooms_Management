using Microsoft.Win32;
using System.Windows;
using Hotel_Rooms_Management.Views;
using System;

namespace Hotel_Rooms_Management.Utils
{
    class DialogService
    {
        public string FilePath { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }

        public bool SaveFileDialog(string name)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files(*.csv)|*.csv";
            saveFileDialog.FileName = name;
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        public bool EnterCustomerDataDialog()
        {
            EnterCustomerDataWindow window = new EnterCustomerDataWindow();
            if (window.ShowDialog() == true)
            {
                Phone = window.Phone;
                FIO = window.FIO;
                Passport = window.Passport;
                return true;
            }
            else return false;
        }


    }
}
