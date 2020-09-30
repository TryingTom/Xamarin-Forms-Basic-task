using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobiiliohjelmointi_task_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        ObservableCollection<Person> PersonList = new ObservableCollection<Person>();
        //public ObservableCollection<Person> PersonList { get { return people; } }

        public ApiPage()
        {
            InitializeComponent();

            PersonList.Add(new Person("Pull down", "To get the real data", 69));

            MyListView.ItemsSource = PersonList;
        }
        private void MyListView_Refreshing(object sender, EventArgs e)
        {
            MyListView.IsRefreshing = true;
            PersonList.Clear();
            PersonList.Add(new Person("Kalle", "Kuopio", 15));
            MyListView.IsRefreshing = false;
        }
    }
}
