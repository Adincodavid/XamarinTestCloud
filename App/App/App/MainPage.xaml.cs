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
        TimeWrapper timer;
        private DateTime _timerStart;
        public MainPage()
        {
            InitializeComponent();
           
            SfCarousel carousel = new SfCarousel() { ItemWidth = 170, ItemHeight = 250 };
            ObservableCollection<SfCarouselItem> collectionOfItems = new ObservableCollection<SfCarouselItem>();
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "area.png", ClassId ="1" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "donut.png" , ClassId = "2" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "pie.png", ClassId = "3" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "series.png", ClassId = "4" });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "step.png", ClassId = "5" });
            carousel.ItemsSource = collectionOfItems;
            this.Content = new StackLayout()
            {
                Children = { carousel, Activity,ListaGenerica }
            };
            carousel.SelectedIndex = 1;
            List<string> Numeros = new List<string>();
            carousel.SelectionChanged += async (object sender, SelectionChangedEventArgs e) =>
            {
                var obj = (SfCarouselItem)e.SelectedItem;
                string Id = obj.ClassId;
                string Nombre = obj.ImageName;
                ListaGenerica.ItemsSource = null;
                await Task.Yield();
                Activity.IsRunning = true;
                await Task.Delay(3000);
                ListaGenerica.ItemsSource = elementoslista;
                Activity.IsRunning = false;
                Numeros.Add(Id);
                var c = Numeros[Numeros.Count - 1];
                await DisplayAlert("Ok", $"{Id},{Nombre}, {c.ToString()}","OK");
            };
        }
        private void TimerElapsedEvt()
        {
            var secondsSinceStart = GetSecondsSinceTimerStart;
            if (secondsSinceStart % 2 == 0)
            {
                
            }
        }

        private int GetSecondsSinceTimerStart
        {
            get
            {
                TimeSpan lapsedTime = DateTime.Now - _timerStart;
                return lapsedTime.Seconds;
            }
        }
    }
}
