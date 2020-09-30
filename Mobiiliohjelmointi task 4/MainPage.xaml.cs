using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mobiiliohjelmointi_task_4
{
    public partial class MainPage : ContentPage
    {
        private double StepValue;
        private Slider slider;
        List<Person> PersonList = new List<Person>();
        public MainPage()
        {
            InitializeComponent();

            // initialize the slider
            StepValue = 1.0;
            slider = new Slider
            {
                Minimum = 0.0f,
                Maximum = 100.0f,
                Value = 0.0f,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            slider.ValueChanged += (sender, args) =>
            {
                lAge.Text = String.Format("The Slider value is {0}", args.NewValue);
            };
        }

        async private void SecondPageButton_Clicked(object sender, EventArgs e)
        {
            // Try catch to check if all the entrys are filled
            try
            {
                // make sure that the user gives the right details
                if (eName.Text.Length < 4 || eAddress.Text.Length < 4 || slider.Value < 10)
                {
                    //otherwise notify accordingly
                    StringBuilder sb = new StringBuilder();

                    if (eName.Text.Length <= 3)
                    {
                        sb.Append("Make sure your Name has 4 or more characters.\n");
                    }
                    if (eAddress.Text.Length <= 3)
                    {
                        sb.Append("Make sure your Address has 4 or more characters.\n");
                    }
                    if (slider.Value < 10)
                    {
                        sb.Append("Make sure you're 10 years or older.\n");
                    }

                    await DisplayAlert("Alert", sb.ToString(), "OK");
                }
                else
                {
                    Person UserInformation = new Person(eName.Text, eAddress.Text, Convert.ToInt32(slider.Value)); // change slider value to int somehow
                    PersonList.Add(UserInformation);
                    await Navigation.PushAsync(new InfoPage(PersonList));
                }
            }
            // expected to get NullReferenceException if the entrys don't have any data
            catch
            {
                await DisplayAlert("Alert", "Make sure to fill every entry", "OK");
            }
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            var newStep = Math.Round(args.NewValue / StepValue);

            slider.Value = newStep * StepValue;
            lAge.Text = String.Format("Age: {0}", newStep);
        }

        async private void ApiPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiPage());
        }
    }
}
