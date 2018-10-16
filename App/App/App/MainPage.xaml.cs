using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.SfCarousel.XForms;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace App
{
    public partial class MainPage : ContentPage
    {
        List<string> elementoslista = new List<string>()
        {
            "Node js","C#","Java","SQL Server","Oracle","Web Services","Cosmos DB","Mongo DB","Entity Framework",".Net Core","Visual Basic .Net","Steve Jobs","Bill Gates","Mac OS","Elementary OS",
        };
        public MainPage()
        {
            InitializeComponent();
            SfCarousel carousel = new SfCarousel() { ItemWidth = 170, ItemHeight = 250 };
            ObservableCollection<SfCarouselItem> collectionOfItems = new ObservableCollection<SfCarouselItem>();
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "area.png" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "donut.png" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "pie.png" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "series.png" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "step.png" });
            carousel.ItemsSource = collectionOfItems;
            this.Content = new StackLayout()
            {
                Children = { carousel, Activity,ListaGenerica }
            };
            carousel.SelectedIndex = 1;

            carousel.SelectionChanged += async (object sender, SelectionChangedEventArgs e) =>
            {
                await Task.Yield();
                Activity.IsRunning = true;
                await Task.Delay(3000);
                Activity.IsRunning = false;
            
            };
            ListaGenerica.ItemsSource = elementoslista;
        }

    }
}
