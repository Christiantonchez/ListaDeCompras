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
        [ObservableProperty] private ShopListItem? _elementoSeleccionado = null;


        public ObservableCollection<ShopListItem> ShopList { get; }


        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
            if (ShopList.Count > 0)
            {
                ElementoSeleccionado = ShopList[0];
            }
            else
            {
                ElementoSeleccionado = null;
            }
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
            ElementoSeleccionado = item;
            NombreDelArticulo = string.Empty;
            Cantidad = 1;
        }

        [RelayCommand]
        public void RemoveShopListItem()
        {
            if (ElementoSeleccionado == null)
            {
                return;
            }
            ShopListItem? nuevoElementoSeleccionado;


            int indice =  ShopList.IndexOf(ElementoSeleccionado);
            if (ShopList.Count > 1)
            {
                if (indice == ShopList.Count - 1)

                {
                    nuevoElementoSeleccionado = ShopList[indice - 1];
                }
                else
                {
                    nuevoElementoSeleccionado = ShopList[indice + 1];
                }

            }

            else
            {

                    nuevoElementoSeleccionado = null;
            }

            ShopList.Remove(ElementoSeleccionado);
            ElementoSeleccionado = nuevoElementoSeleccionado;
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
