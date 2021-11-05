using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(tesztAZ), Name = "tesztAZ", IsUnique = true)]
    public partial class Tesztek
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int tesztAZ { get; set; }
        [Required]
        [StringLength(50)]
        public string tesznev { get; set; }
        [Required]
        [StringLength(30)]
        public string tipus { get; set; }
        [Column(TypeName = "bool")]
        public bool kotelezo { get; set; }
        [Column(TypeName = "int(11)")]
        public int eletkori_kitoltes_kezdete_ev { get; set; }
        [Column(TypeName = "int(11)")]
        public int eletkori_kitoltes_kezdete_honap { get; set; }
        [Column(TypeName = "int(11)")]
        public int eletkori_kitoltes_vege_ev { get; set; }
        [Column(TypeName = "int(11)")]
        public int eletkori_kitoltes_vege_honap { get; set; }
    }
}
