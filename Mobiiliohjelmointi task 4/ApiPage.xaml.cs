using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobiiliohjelmointi_task_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        List<AddressFromApi> PersonList = new List<AddressFromApi>();

        public ApiPage()
        {
            InitializeComponent();

            PersonList.Add(new AddressFromApi(69, "Pull ", "Down ", "Pull", "Down"));
            PersonList.Add(new AddressFromApi(420, "To ", "Refresh ", "To ", "Refresh "));

            MyListView.ItemsSource = PersonList;
        }
        async private void MyListView_Refreshing(object sender, EventArgs e)
        {
            // start the refreshing animation and clear the list
            MyListView.IsRefreshing = true;
            PersonList.Clear();

            // get Json from API
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://codez.savonia.fi/jussi/api/json_data.php");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // deserialize the response
            PersonList = JsonConvert.DeserializeObject<List<AddressFromApi>>(responseBody);
            MyListView.ItemsSource = PersonList;

            // stop the refreshing animation
            MyListView.IsRefreshing = false;
        }
    }
}
