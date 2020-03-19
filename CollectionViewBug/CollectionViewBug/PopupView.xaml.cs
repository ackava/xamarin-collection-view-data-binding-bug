using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewBug
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView : ContentView
    {
        public PopupView()
        {
            InitializeComponent();

            this.BindingContext = new PopupViewModel();
        }
    }

    public class PopupViewModel: System.ComponentModel.INotifyPropertyChanged
    {
        public PopupViewModel()
        {
            Device.BeginInvokeOnMainThread(async () => {

                await Task.Delay(1000);

                this.Items = new List<Item> {
                    new Item
                    {
                        Label = "1",
                        Value = "1"
                    },
                    new Item
                    {
                        Label = "2",
                        Value = "2"
                    }
                };
            
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Item> items;

        public List<Item> Items
        {
            get { return items; }
            set {
                items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }

    }

    public class Item
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}