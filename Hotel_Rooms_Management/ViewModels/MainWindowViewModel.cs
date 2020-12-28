using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using Hotel_Rooms_Management.Models;
using Hotel_Rooms_Management.Utils;

namespace Hotel_Rooms_Management.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Room> availableRooms;
        public ObservableCollection<Room> AllRooms { get; set; }

        private Room selectedRoom;
        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set
            {
                selectedRoom = value;
                OnPropertyChanged("SelectedRoom");
            }
        }
        private Visibility RoomVisibility = Visibility.Visible;
        public Visibility roomVisibility
        {
            get { return RoomVisibility; }
            set
            {
                RoomVisibility = value;
                OnPropertyChanged("roomVisibility");
            }
        }

        private DbOperations dbo;
        private DialogService ds;
        private FileService fs;

        public MainWindowViewModel()
        {
            dbo = new DbOperations();
            ds = new DialogService();
            fs = new FileService();

            availableRooms = dbo.GetAvailableRooms();
            AllRooms = new ObservableCollection<Room>();
        }
    }
}
