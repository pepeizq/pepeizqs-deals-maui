using System.Data.SqlClient;

namespace pepeizqs_deals_maui.Paginas
{
    public partial class Portada : ContentPage
    {
        public Portada()
        {
            InitializeComponent();

			CargarObjetosVentana();

			string idioma = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

			Noticias.Noticias.Cargar(idioma);
		}

		public void CargarObjetosVentana()
		{
			ObjetosVentana.spNoticias = spNoticias;
		}

		public static class ObjetosVentana
		{
			public static VerticalStackLayout spNoticias { get; set; }
		}
	}
}
