using Microsoft.Data.SqlClient;
using static pepeizqs_deals_maui.Paginas.Portada;

namespace pepeizqs_deals_maui.Noticias
{
	public static class Noticias
	{
		public static void Cargar(string idioma)
		{
			List<Noticia> noticias = new List<Noticia>();

			using (SqlConnection conexion = new SqlConnection(DatosPersonales.Servidor))
			{
				conexion.Open();

				if (conexion.State == System.Data.ConnectionState.Open)
				{
					string sqlBuscar = "SELECT * FROM noticias WHERE (GETDATE() BETWEEN fechaEmpieza AND fechaTermina) AND (GETDATE() - 3 < fechaEmpieza) ORDER BY id DESC";

					using (SqlCommand comando = new SqlCommand(sqlBuscar, conexion))
					{
						using (SqlDataReader lector = comando.ExecuteReader())
						{
							while (lector.Read())
							{
								Noticia noticia = new Noticia();

								noticia.Id = lector.GetInt32(0);
								noticia.Tipo = int.Parse(lector.GetString(1));

								if (lector.IsDBNull(2) == false)
								{
									noticia.Imagen = lector.GetString(2);
								}

								if (lector.IsDBNull(3) == false)
								{
									noticia.Enlace = lector.GetString(3);
								}

								if (lector.IsDBNull(4) == false)
								{
									noticia.Juegos = lector.GetString(4);
								}

								if (lector.IsDBNull(5) == false)
								{
									noticia.FechaEmpieza = lector.GetDateTime(5);
								}

								if (lector.IsDBNull(6) == false)
								{
									noticia.FechaTermina = lector.GetDateTime(6);
								}

								if (lector.IsDBNull(7) == false)
								{
									noticia.BundleTipo = int.Parse(lector.GetString(7));
								}

								if (lector.IsDBNull(8) == false)
								{
									noticia.GratisTipo = int.Parse(lector.GetString(8));
								}

								if (lector.IsDBNull(9) == false)
								{
									noticia.SuscripcionTipo = int.Parse(lector.GetString(9));
								}

								if (lector.IsDBNull(10) == false)
								{
									noticia.TituloEn = lector.GetString(10);
								}

								if (lector.IsDBNull(11) == false)
								{
									noticia.TituloEs = lector.GetString(11);
								}

								if (lector.IsDBNull(12) == false)
								{
									noticia.ContenidoEn = lector.GetString(12);
								}

								if (lector.IsDBNull(13) == false)
								{
									noticia.ContenidoEs = lector.GetString(13);
								}

								noticias.Add(noticia);
							}
						}
					}
				}
			}

			if (noticias != null)
			{
				if (noticias.Count > 0)
				{ 
					ObjetosVentana.spNoticias.Children.Clear();
					ObjetosVentana.spNoticias.IsVisible = true;

					foreach (var noticia in noticias)
					{
						Border fondo = new Border
						{
							BackgroundColor = (Color)Application.Current.Resources["fondoBotonPequeño"],
							Stroke = (Color)Application.Current.Resources["fondoOscuro"],
							StrokeThickness = 1
						};

						Grid grid = new Grid();

						ColumnDefinition col1 = new ColumnDefinition
						{
							Width = new GridLength(1, GridUnitType.Auto)
						};

						grid.ColumnDefinitions.Add(col1);

						ColumnDefinition col2 = new ColumnDefinition
						{
							Width = new GridLength(1, GridUnitType.Star)
						};

						grid.ColumnDefinitions.Add(col2);

						Image imagen = new Image
						{
							Source = noticia.Imagen,
							HeightRequest = 110,
							WidthRequest = 200,
							Aspect = Aspect.AspectFill
						};

						imagen.SetValue(Grid.ColumnProperty, 0);
						grid.Children.Add(imagen);

						Label lb = new Label();
						lb.Margin = new Thickness(20);
						lb.VerticalTextAlignment = TextAlignment.Center;
						lb.FontFamily = "MotivaSansRegular";
						lb.FontSize = 16;

						if (string.IsNullOrEmpty(idioma) == false)
						{
							if (idioma.ToLower() == "es")
							{
								lb.Text = noticia.TituloEs;
							}
							else
							{
								lb.Text = noticia.TituloEn;
							}
						}

						lb.SetValue(Grid.ColumnProperty, 1);
						grid.Children.Add(lb);

						fondo.Content = grid;

						ObjetosVentana.spNoticias.Children.Add(fondo);
					}
				}
			}
		}
	}
}
