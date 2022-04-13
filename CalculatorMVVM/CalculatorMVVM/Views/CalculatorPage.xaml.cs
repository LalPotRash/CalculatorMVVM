using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalculatorMVVM.ViewModels;

namespace CalculatorMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
            this.BindingContext = new CalculatorViewModel();
        }
    }
}