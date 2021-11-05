using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(diagnozisAZ), Name = "diagnozisAZ", IsUnique = true)]
    public partial class Diagnózisok
    {
        [Key]
        [Column(TypeName ="int(11)")]
        public int diagnozisAZ { get; set; }
        [Required]
        [StringLength(5)]
        public string tipusa { get; set; }
        [Column(TypeName ="date")]
        public DateTime diagnozis_adas_datuma { get; set; }
        [Column(TypeName ="float")]
        public float diagnozis_kodja { get; }
        [Required]
        [StringLength(100)]
        public string diagnozis_megnevezese { get; set; }
        [Column(TypeName ="boolean")]
        public bool logopediai_ellatas_kell_e { get; set; }
    }
}
