using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Dtos
{
    public class VisitanteDto
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
        public bool? EstadoAcceso { get; set; }
        public string EmpleadoResponsable { get; set; }
        public List<Equipo> Equipos { get; set; }
        public List<Arl> Arl { get; set; }
        public List<Incidente> Incidentes { get; set; }
        public List<VehiculosVisitante> Vehiculos { get; set; }
    }
}
