using Shop.List.Gui.Models;
using System.Collections.ObjectModel;

namespace Shop.List.Gui.ViewModels
{
    public class ShopListViewModel
    {
        public ObservableCollection<ShopListItem> ShopList { get; }
        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
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
