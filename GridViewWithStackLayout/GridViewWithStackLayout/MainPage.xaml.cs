using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GridViewWithStackLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Grid with stackLayout";
            var myGrid= new Grid(){RowSpacing = 1, ColumnSpacing = 1};
            myGrid.RowDefinitions.Add(new RowDefinition(){ Height = new GridLength(1, GridUnitType.Star)});
            myGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            myGrid.ColumnDefinitions.Add(new ColumnDefinition(){Width = new GridLength(1,GridUnitType.Star)});
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            // Define grid Children
            myGrid.Children.Add(new StackLayout()
            {
                BackgroundColor = Color.Aqua
            },0,0);
            myGrid.Children.Add(new StackLayout() {BackgroundColor = Color.Bisque}, 0, 1);
            myGrid.Children.Add(new StackLayout() {BackgroundColor = Color.Blue}, 1, 0);
            myGrid.Children.Add(new StackLayout() {BackgroundColor = Color.CadetBlue}, 1, 1);
            // Define Content Page
            Content = myGrid;
        }
    }
}
