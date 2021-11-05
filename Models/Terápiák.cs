using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(terapiaAZ), Name = "terapiaAZ", IsUnique = true)]
    public partial class Terápiák
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int terapiaAZ { get; set; }
        [Column(TypeName = "bool")]
        public bool szukseges_e { get; set; }
        [Column(TypeName = "int(11)")]
        public int ellato_szakemberID { get; set; }
        [Column(TypeName = "int(11)")]
        public int terapia_taneve { get; set; }
        [Required]
        [StringLength(50)]
        public string ellatas_helye { get; set; }
        [Required]
        [StringLength(10)]
        public string ellatas_napja { get; set; }
        [Column(TypeName = "int(11)")]
        public int ellatas_idopontja { get; set; }
    }
}
