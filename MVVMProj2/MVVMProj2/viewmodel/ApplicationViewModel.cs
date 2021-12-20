using MVVMProj2.command;
using MVVMProj2.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProj2.viewmodel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PhoneModel> Phones { get; set; }

        private PhoneModel selectedPhone;
        public PhoneModel SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged();
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<PhoneModel>
            {
                new PhoneModel { Title="iPhone 7", Company="Apple", Price=56000 },
                new PhoneModel {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new PhoneModel {Title="Elite x3", Company="HP", Price=56000 },
                new PhoneModel {Title="Mi5S", Company="Xiaomi", Price=35000 },
                new PhoneModel {Title="3310", Company="Nokia", Price=150 }
            };

            AddSomeCommand = new RelayCommand(obj =>
            {
                PhoneModel phone = new PhoneModel();
                Phones.Insert(0, phone);
                SelectedPhone = phone;
            });

            RemoveSomeCommand = new RelayCommand(obj =>
            {
                var phone = obj as PhoneModel;
                if (phone != null)
                {
                    Phones.Remove(phone);
                }
            },
            (obj) => Phones.Count > 0);
        }
        public RelayCommand AddSomeCommand { get; }
        public RelayCommand RemoveSomeCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
