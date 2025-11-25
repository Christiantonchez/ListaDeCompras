using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shop.List.Gui.Models;
using System.Collections.ObjectModel;
namespace Shop.List.Gui.ViewModels
{
    public partial class ShopListViewModel : ObservableObject
    {
        [ObservableProperty] private string _nombreDelArticulo = string.Empty;
        [ObservableProperty] private int _cantidad = 1;


        public ObservableCollection<ShopListItem> ShopList { get; }


        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
        }

        [RelayCommand] public void AddShopListItem()
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
    }
}
