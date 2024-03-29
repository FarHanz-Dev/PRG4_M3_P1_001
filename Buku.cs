﻿
using System.ComponentModel.DataAnnotations;

namespace PRG4_M3_P1_001.Models
{

    public class Buku
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Judul wajib diisi.")]
        [MaxLength(30,ErrorMessage ="Judul maksimal 30 Karakter.")]
        public string judul { get; set; }

        [Required(ErrorMessage = "Penulis wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Judul maksimal 30 Karakter.")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "Penulis hanya boleh diisi huruf.")]
        public string penulis { get; set; }

        [Required(ErrorMessage = "Penerbit wajib diisi.")]
        public string penerbit { get; set; }

        [Required(ErrorMessage = "ISSN wajib diisi")]
        [RegularExpression("^[0-9]{4}-[0-9]{4}$",ErrorMessage = "Format ISSN tidak valid. Gunakan format XXXX-XXXX.")]
        public string issn { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Tahun tidak valid")]
        [RegularExpression("^(19|20)\\d{2}$", ErrorMessage = "Tahun Tidak Valid")]
        public int tahun { get; set; }

        [Range(0,1,ErrorMessage ="Status tidak valid.")]
        public int status { get; set; }



    }

   
}

