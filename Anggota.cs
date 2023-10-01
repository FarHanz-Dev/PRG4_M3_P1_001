using System.ComponentModel.DataAnnotations;
namespace PRG4_M3_P1_001.Models
{
    public class Anggota
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama maksimal 30 Karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama hanya boleh diisi huruf.")]
        public string Nama { get; set; }

        [Required(ErrorMessage = "Umur wajib diisi.")]
   
        public int Umur { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi.")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "No HP wajib diisi")]
       
        public string NoHp { get; set; }

      

    }
}
