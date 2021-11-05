using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(ovodaAZ), Name = "tesztAZ", IsUnique = true)]
    public partial class Óvodák
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int ovodaAZ { get; set; }
        [Required]
        [StringLength(100)]
        public string ovoda_neve { get; set; }
        [Required]
        [StringLength(100)]
        public string ovoda_cime { get; set; }
        [Column(TypeName = "int(11)")]
        public int ovoda_telszama { get; set; }
        [Required]
        [StringLength(50)]
        public string ovoda_email { get; set; }
        [Required]
        [StringLength(60)]
        public string ovoda_vezeto_neve { get; set; }
        [Required]
        [StringLength(60)]
        public string fenntarto { get; set; }
    }
}
