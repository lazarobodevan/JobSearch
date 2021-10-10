using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.APP.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterJob : ContentPage {
        public RegisterJob() {
            InitializeComponent();
        }

        private void GoBack(object sender, EventArgs e) {
            Navigation.PopModalAsync();
        }

        private void Save(object sender, EventArgs e) {
            DisplayAlert("Vaga salva", "Vaga cadastrada", "Ok");
            Navigation.PopModalAsync();
        }
    }
}