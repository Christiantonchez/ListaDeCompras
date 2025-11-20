using Shop.List.Gui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Shop.List.Gui.ViewModels
{
    public class ShopListViewModel : INotifyPropertyChanged
    {

        private string _nomnbreDelArticulo = string.Empty;
        private int _cantidad = 1;

        public int Cantidad

        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)

                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }

            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NombreDelArticulo

        {
            get => _nomnbreDelArticulo;
            set
            {
                if (_nomnbreDelArticulo != value)

                {
                    _nomnbreDelArticulo = value;
                    OnPropertyChanged(nameof(NombreDelArticulo));
                }

            }

        }
        public ObservableCollection<ShopListItem> ShopList { get; }

        public ICommand AddShopListItemComand { get; private set; }



        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
            AddShopListItemComand = new Command(AddShopListItem);
        }

        public void AddShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || Cantidad <= 0)
            {
                return;
            }

            Random generador = new Random();
            var item = new ShopListItem()
            {
                id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = this.Cantidad,
                Comprado = false,
            };

            ShopList.Add(item);

            NombreDelArticulo = string.Empty;
            Cantidad = 1;
        }
        private void CargarDatos()
        {
            ShopList.Add(new ShopListItem()
            {
                id = 1,
                Nombre = "PAN",
                Cantidad = 1,
                Comprado = false


            });

            ShopList.Add(new ShopListItem()
            {
                id = 2,
                Nombre = "LECHE",
                Cantidad = 3,
                Comprado = false


            });

            ShopList.Add(new ShopListItem()
            {
                id = 3,
                Nombre = "QUESO",
                Cantidad = 100,
                Comprado = false


            });


        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
