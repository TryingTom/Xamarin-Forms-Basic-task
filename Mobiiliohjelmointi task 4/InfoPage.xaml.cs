using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Collections;

namespace Mobiiliohjelmointi_task_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {

        public InfoPage(IEnumerable<Person> data)
        {
            InitializeComponent();

            ArrayList StringifiedList = new ArrayList {};

            foreach(Person person in data)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Name: {0} ", person.Name);
                sb.AppendFormat("Address: {0} ", person.Address);
                sb.AppendFormat("Age: {0} ", person.Age);

                StringifiedList.Add(sb.ToString());
            }

            MyListView.ItemsSource = StringifiedList;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
