using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(oktatasi_azonosito), Name = "tesztAZ", IsUnique = true)]
    public partial class Gyerekek
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int oktatasi_azonosito { get; set; }
        [Required]
        [StringLength(60)]
        public string gyerek_neve { get; set; }
        [Required]
        [StringLength(30)]
        public string szul_hely { get; set; }
        [Column(TypeName = "date")]
        public DateTime szul_ido { get; set; }
        [Required]
        [StringLength(60)]
        public string anyja_neve { get; set; }
        [Column(TypeName = "int(11)")]
        public int elerhetosegAZ { get; set; }
        [Column(TypeName = "int(11)")]
        public int ovodaAZ { get; set; }
        [Column(TypeName = "int(11)")]
        public int diagnozisAZ { get; set; }
    }
}
