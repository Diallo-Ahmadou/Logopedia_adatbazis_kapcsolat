using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(elerhetosegAZ), Name = "tesztAZ", IsUnique = true)]
    public partial class Gyerek_elérhetőségek
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int elerhetosegAZ { get; set; }
        [Required]
        [StringLength(60)]
        public string gondviselo_neve { get; set; }
        [Column(TypeName = "int(11)")]
        public int gondviselo_telefonszama { get; set; }
        [Required]
        [StringLength(50)]
        public string gondviselo_email { get; set; }
        [Required]
        [StringLength(100)]
        public string gondviselo_lakcim { get; set; }
    }
}
