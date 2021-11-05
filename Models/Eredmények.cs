using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(tesztAZ), Name = "tesztAZ", IsUnique = true)]
    public partial class Eredmények
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int tesztAZ { get; set; }
        [Column(TypeName = "int(11)")]
        public int oktatasi_azonosito { get; set; }
        [Column(TypeName = "date")]
        public DateTime kitoltes_datuma { get; set; }
        [Column(TypeName = "int(11)")]
        public int aktualis_eletkor_ev { get; set; }
        [Column(TypeName = "int(11)")]
        public int aktualis_eletkor_honap { get; set; }
        [Column(TypeName = "int(11)")]
        public int szokincs_pontszam { get; set; }
        [Required]
        [StringLength(30)]
        public string szokincs_szint { get; set; }
        [Column(TypeName = "int(11)")]
        public int mondathasznalat_pontszam { get; set; }
        [Required]
        [StringLength(30)]
        public string mondathasznalat_szint { get; set; }
        [Column(TypeName = "int(11)")]
        public int nyelvhasznalat_pontszam { get; set; }
        [Required]
        [StringLength(30)]
        public string nyelvhasznalat_szint { get; set; }
        [Column(TypeName = "int(11)")]
        public int elmaradas_merteke { get; set; }
        [Column(TypeName = "int(11)")]
        public int terapiaAZ { get; set; }
    }
}
