﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblFichas
    {
        [Key]
        public int IdFicha { get; set; }

        //relacion
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public int NumParto { get; set; }
        public DateTime FechaServio { get; set; }

        // relacion 
        public int IdVarraco { get; set; }
        public virtual tblVarracos Varracos { get; set; }

        public DateTime FechaParto { get; set; }
        public int NacidosVivos { get; set; }
        public int NacidosMuertos { get; set; }
        public int NacidosMomias { get; set; }
        public int TotalNacidos { get; set; }
        public double PesoPromedio1D { get; set; }
        public int NumDestetado { get; set; }
        public double PesoPromedio28D { get; set; }
        public DateTime FechaDestete { get; set; }
        
        //Relacion 
        public int IdEmpleados { get; set; }
        public virtual tblEmpleados Empleados { get; set; }


    }
}