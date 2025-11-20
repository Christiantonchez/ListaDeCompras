
using Shop.List.Gui.ViewModels;

namespace Shop.List.Gui.Views
{
    public partial class ShopListPage : ContentPage
    {
        public ShopListPage()
        {
            InitializeComponent();
            BindingContext = new ShopListViewModel();
        }
    }
}
