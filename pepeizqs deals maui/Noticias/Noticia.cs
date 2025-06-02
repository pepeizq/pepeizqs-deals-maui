public class Noticia
{
	public int Id { get; set; }
	public int Tipo { get; set; }
	public int BundleTipo { get; set; }
	public int GratisTipo { get; set; }
	public int SuscripcionTipo { get; set; }
	public string TituloEn { get; set; }
	public string TituloEs { get; set; }
	public string ContenidoEn { get; set; }
	public string ContenidoEs { get; set; }
	public string Imagen { get; set; }
	public string Enlace { get; set; }
	public string Juegos { get; set; }
	public DateTime FechaEmpieza { get; set; }
	public DateTime FechaTermina { get; set; }
	public int BundleId { get; set; }
}