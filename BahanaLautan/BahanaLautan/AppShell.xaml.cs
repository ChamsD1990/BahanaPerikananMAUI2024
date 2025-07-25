
//
using BahanaLautan.Source.Model.Permintaan;
using BahanaLautan.Views.Account;
using BahanaLautan.Views.History;
using BahanaLautan.Views.Home;
using BahanaLautan.Views.Home.Kerja;
using BahanaLautan.Views.Home.Kerja.DaftarKebutuhanKerja;
using BahanaLautan.Views.Home.Kerja.EstimasiKeberangkatan;
using BahanaLautan.Views.Home.Kerja.HasilTangkap;
using BahanaLautan.Views.Home.Kerja.PermintaanAngkutanLogistik;
using BahanaLautan.Views.Home.Kerja.PermintaanBoxIkan;
using BahanaLautan.Views.Home.Kerja.PermintaanSegelIkan;
using BahanaLautan.Views.Home.Permintaan;
using BahanaLautan.Views.Home.Permintaan.AturKelompokKerja;
using BahanaLautan.Views.Home.Permintaan.KasbonPribadi;
using BahanaLautan.Views.Home.Permintaan.PeralatanTangkap;
using BahanaLautan.Views.Home.Permintaan.PerbaikanAlatTangkap;
using BahanaLautan.Views.Home.Permintaan.PerbaikanKapal;
using BahanaLautan.Views.Home.Permintaan.PermintaanSparepart;
using BahanaLautan.Views.Notification; 

namespace BahanaLautan
{
    public partial class AppShell : Shell
    {
        public Command AddCommand { get; private set; }
        public AppShell()
        {
            AddCommand = new Command(OnAddClicked);
            BindingContext = new ModelActionBar(); 


            InitializeComponent(); // Only call once

            // Remove the toolbar item if needed
            var toolbarItem = this.ToolbarItems.FirstOrDefault(t => t is ToolbarItem item && item == AddToolbarItem);
            if (toolbarItem != null)
            {
                this.ToolbarItems.Remove(toolbarItem);
            }

            Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

            Routing.RegisterRoute("HomePage", typeof(PageHome));
            Routing.RegisterRoute("AccountPage", typeof(PageAccount));
            Routing.RegisterRoute("HistoryPage", typeof(PageHistory));
            Routing.RegisterRoute("NotificationPage", typeof(PageNotification));


            Routing.RegisterRoute(nameof(PagePermintaan), typeof(PagePermintaan));
            Routing.RegisterRoute(nameof(PageKerja), typeof(PageKerja));

            //permintaan
            Routing.RegisterRoute(nameof(FormKelompokKerja), typeof(FormKelompokKerja));
            Routing.RegisterRoute(nameof(FormPeralatanTangkap), typeof(FormPeralatanTangkap));
            Routing.RegisterRoute(nameof(FormPermintaanAlatKapal), typeof(FormPermintaanAlatKapal));
            Routing.RegisterRoute(nameof(FormPerbaikanKapal), typeof(FormPerbaikanKapal));
            Routing.RegisterRoute(nameof(FormPermintaanSparepart), typeof(FormPermintaanSparepart));

            Routing.RegisterRoute(nameof(ListPerbaikanKapal), typeof(ListPerbaikanKapal));
            Routing.RegisterRoute(nameof(ListPeralatanTangkap), typeof(ListPeralatanTangkap));
            Routing.RegisterRoute(nameof(ListPerbaikanAlatKapal), typeof(ListPerbaikanAlatKapal));
            Routing.RegisterRoute(nameof(ListPermintaanSparepart), typeof(ListPermintaanSparepart));
            Routing.RegisterRoute(nameof(ListKasbonPribadi), typeof(ListKasbonPribadi));

            //kerja 
            Routing.RegisterRoute(nameof(FormEstimasiKeberangatanTim), typeof(FormEstimasiKeberangatanTim)); 
            Routing.RegisterRoute(nameof(FormKasbonOperational), typeof(FormKasbonOperational));
            Routing.RegisterRoute(nameof(FormPermintaanKebutuhanBBM), typeof(FormPermintaanKebutuhanBBM));
            Routing.RegisterRoute(nameof(FormPermintaanEsbatu), typeof(FormPermintaanEsbatu));
            Routing.RegisterRoute(nameof(FormPermintaanBahanMakanan), typeof(FormPermintaanBahanMakanan));
            /* */
            Routing.RegisterRoute(nameof(FormPermintaanBoxIkan), typeof(FormPermintaanBoxIkan));
            Routing.RegisterRoute(nameof(FormPermintaanSegelIkan), typeof(FormPermintaanSegelIkan));
            Routing.RegisterRoute(nameof(FormPermintaanAngkutanLogistik), typeof(FormPermintaanAngkutanLogistik));
            Routing.RegisterRoute(nameof(FormHasilTangkap), typeof(FormHasilTangkap)); 
            /* */
            Routing.RegisterRoute(nameof(ListKeberangkatanTeam), typeof(ListKeberangkatanTeam));
            Routing.RegisterRoute(nameof(ListDaftarKebutuhanKerja), typeof(ListDaftarKebutuhanKerja));

        }

        //protected override void OnNavigated(ShellNavigatedEventArgs args)
        //{
        //    base.OnNavigated(args);
        //    string currentRoute = args.Source.ToString(); 
        //    Debug.WriteLine($"Navigated to: {currentRoute}");
        //    Console.WriteLine($"Navigated to: {currentRoute}");

        //}
         



        private void OnAddClicked()
        {
            // Your logic here
        }
    }
}
