namespace ApiControlAcceso.MODELS.Dtos
{
    public class VehiclesDto
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Detalle { get; set; }
    }
}
