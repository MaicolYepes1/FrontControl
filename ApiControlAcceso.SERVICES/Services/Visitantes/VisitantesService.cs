using ApiControlAcceso.INFRA.Repository.Interfaces;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using AutoMapper;
using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApiControlAcceso.SERVICES.Services.Visitantes
{
    public class VisitantesService : IVisitantesService
    {
        #region Dependencias
        private readonly IGenericRepository<Visitante> _reporitory;
        private readonly IMapper _mapper;
        private readonly AppDataContext _context;
        private readonly IEquiposService _equipos;
        private readonly IVehiculosService _vehiculo;
        private readonly IArlService _arl;
        private readonly IIncidentesService _inc;
        private readonly SeDataContext _SeContext;
        #endregion

        #region Constructor
        public VisitantesService(IGenericRepository<Visitante> repository, IMapper mapper, AppDataContext context,
            IEquiposService equipos, IVehiculosService vehiculo, IArlService arl, IIncidentesService inc, SeDataContext seContext)
        {
            _reporitory = repository;
            _mapper = mapper;
            _context = context;
            _equipos = equipos;
            _vehiculo = vehiculo;
            _arl = arl;
            _inc = inc;
            _SeContext = seContext;
        }
        #endregion

        #region Metodos
        public async Task<List<VisitanteDto>> Get()
        {
            try
            {
                List<VisitanteDto> VisOk = new List<VisitanteDto>();
                VisitanteDto visitante = new VisitanteDto();

                var visi = _context.Visitantes.Select(s => new VisitanteDto
                {
                    Id = s.Id,
                    Identificacion = s.Identificacion,
                    Nombres = s.Nombres,
                    Apellidos = s.Apellidos,
                    TipoDoc = s.TipoDoc,
                    TipoVisitante = s.TipoVisitante,
                    Empresa = s.Empresa,
                    EstadoAcceso = s.EstadoAcceso,
                    EmpleadoResponsable = s.EmpleadoResponsable,
                }).ToList();
                
                VisOk.Add(visitante);
                return visi;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<VisitanteDto> GetInfo(GetInfoLoad model)
        {
            try
            {
                VisitanteDto visitor = new VisitanteDto();
                var visitante = _context.Visitantes.Where(x => x.Id == model.Id).FirstOrDefault();
                if (visitante != null)
                {
                    visitor.Id = visitante.Id;
                    visitor.Identificacion = visitante.Identificacion;
                    visitor.Nombres = visitante.Nombres;
                    visitor.Apellidos = visitante.Apellidos;
                    visitor.CodigoTarjeta = visitante.CodigoTarjeta;
                    visitor.Correo = visitante.Correo;
                    visitor.Detalle = visitante.Detalle;
                    visitor.Empresa = visitante.Empresa;
                    visitor.EstadoAcceso = visitante.EstadoAcceso;
                    visitor.FExpedicionDoc = visitante.FExpedicionDoc;
                    visitor.Firma = visitante.Firma;
                    visitor.Foto = visitante.Foto;
                    visitor.Genero = visitante.Genero;
                    visitor.EmpleadoResponsable = visitante.EmpleadoResponsable;
                    visitor.Profesion = visitante.Profesion;
                    visitor.Rh = visitante.Rh;
                    visitor.TipoDoc = visitante.TipoDoc;
                    visitor.TipoVisitante = visitante.TipoVisitante;
                    visitor.Arl = await _context.Arls.Where(a => a.IdVisitante == model.Id).ToListAsync();
                    visitor.Vehiculos = await _context.VehiculosVisitantes.Where(v => v.IdVisitante == model.Id).ToListAsync();
                    visitor.Incidentes = await _context.Incidentes.Where(i => i.IdVisitante == model.Id).ToListAsync();
                    visitor.Equipos = await _context.Equipos.Where(e => e.IdVisitante == model.Id).ToListAsync();
                }
                else
                {
                    return null;
                }

                return visitor;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> InsertOrUpdate(VisitanteLoad visitante)
        {
            try
            {
                if (visitante != null)
                {
                    var map = _mapper.Map<Visitante>(visitante);
                    var visi = _context.Visitantes.Where(x => x.Identificacion == visitante.Identificacion).FirstOrDefault();
                    if (visi == null)
                    {
                        var insert = await _reporitory.Insert(map);
                    }
                    else
                    {
                        visi.EmpleadoResponsable = visitante.Responsable;
                        visi.Identificacion = visitante.Identificacion;
                        visi.Nombres = visitante.Nombres;
                        visi.Apellidos = visitante.Apellidos;
                        visi.CodigoTarjeta = visitante.CodigoTarjeta;
                        visi.Correo = visitante.Correo;
                        visi.Detalle = visitante.Detalle;
                        visi.Empresa = visitante.Empresa;
                        visi.EstadoAcceso = visitante.EstadoAcceso;
                        visi.FExpedicionDoc = visitante.FExpedicionDoc;
                        visi.Firma = visitante.Firma;
                        visi.Foto = visitante.Foto;
                        visi.Genero = visitante.Genero;
                        visi.Profesion = visitante.Profesion;
                        visi.Rh = visitante.Rh;
                        visi.TipoDoc = visitante.TipoDoc;
                        visi.TipoVisitante = visitante.TipoVisitante;
                        _context.Update(visi);
                        await _context.SaveChangesAsync();
                    }
                    var idVis = _context.Visitantes.Where(x => x.Identificacion == visitante.Identificacion).FirstOrDefault();
                    if (idVis != null)
                    {
                        visitante.Id = idVis.Id;
                    }                    
                    //await _equipos.InsertOrUpdate(visitante);
                    //await _vehiculo.InsertOrUpdate(visitante);
                    //await _arl.InsertOrUpdate(visitante);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<bool> Delete(GetInfoLoad model)
        {
            try
            {
                var visitante = _context.Visitantes.Where(x => x.Id == model.Id).FirstOrDefault();
                if (visitante != null)
                {
                    _reporitory.Delete(visitante.Id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> AccessState(GetInfoLoad model)
        {
            try
            {
                var visitante = _context.Visitantes.Where(x => x.Id == model.UserId).FirstOrDefault();
                if (visitante != null)
                {
                    if (model.State == 1)
                    {
                        visitante.EstadoAcceso = true;
                        visitante.FechaIngreso = DateTime.Now;
                        _context.Visitantes.Update(visitante);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        visitante.EstadoAcceso = false;
                        visitante.FechaSalida = DateTime.Now;
                        _context.Visitantes.Update(visitante);
                        _SeContext.Database.ExecuteSqlRaw(" EXEC SecurityExpert.dbo.Agil_spGetUser @nIdentification = {0}, @nID = '', @nSite = ''", model.Id);
                        await _context.SaveChangesAsync();
                        
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
