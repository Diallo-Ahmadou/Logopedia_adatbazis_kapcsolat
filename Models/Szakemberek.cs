using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    [Index(nameof(ellato_szakemberID), Name = "ellato_szakemberID", IsUnique = true)]
    public partial class Szakemberek
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int ellato_szakemberID { get; set; }
        [Required]
        [StringLength(60)]
        public string nev { get; set; }
        [Required]
        [StringLength(30)]
        public string felhasznalo_nev { get; set; }
        [Required]
        [StringLength(10)]
        public string jelszo { get; set; }
        [Required]
        [StringLength(100)]
        public string munkahely { get; set; }
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Column(TypeName = "int(11)")]
        public int telefonszam { get; set; }
    }
}
