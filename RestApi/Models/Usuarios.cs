using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string numerotelefono1 { get; set; }
        public string numerotelefono2 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
       
        //define la propidad de navegacion
        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<ActividadesAmigos> ActividadesAmigos { get; set; }
    }
}