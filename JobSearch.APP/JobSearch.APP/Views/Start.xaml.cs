using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.APP.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage {
        public Start() {
            InitializeComponent();
        }

        private void GoVisualizer(object sender, EventArgs e) {
            Navigation.PushAsync(new Visualizer());
        }

        private void GoRegisterJob(object sender, EventArgs e) {
            Navigation.PushModalAsync(new RegisterJob());
        }

        private void FocusWord(object sender, EventArgs e) {
            TxtWord.Focus();
        }

        private void FocusCityState(object sender, EventArgs e) {
            TxtCityState.Focus();
        }
    }
}