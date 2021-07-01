using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Loads.Visitantes
{
    public class VisitanteLoad
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string TipoDoc { get; set; }
        public string FExpedicionDoc { get; set; }
        public string Rh { get; set; }
        public string CodigoTarjeta { get; set; }
        public string Profesion { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Detalle { get; set; }
        public string TipoVisitante { get; set; }
        public string Empresa { get; set; }
        public string Foto { get; set; }
        public string Firma { get; set; }
        public bool EstadoAcceso { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public List<Equipo> Equipo { get; set; }
        public List<Arl> Arl { get; set; }
        public List<Incidente> Incidente { get; set; }
        public List<VehiculosVisitante> Vehiculo { get; set; }
    }
}
