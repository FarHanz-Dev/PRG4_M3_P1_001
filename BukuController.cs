using Microsoft.AspNetCore.Mvc;
using PRG4_M3_P1_001.Models;
using System.Collections.Generic;
using System.Linq;

namespace PRG4_M3_P1_001.Controllers
{
    public class BukuController : Controller
    {
        private static List<Buku> bukus = InitializeData(); // Inisialisasi list bukus dengan data awal

        private static List<Buku> InitializeData()
        {
            List<Buku> initialData = new List<Buku>
            {
                new Buku
                {
                    id = 1,
                    judul = "Boyolali",
                    penulis = "Roni Prasetyo",
                    penerbit = "ABC Publications",
                    issn = "1234-7858",
                    tahun = 2020,
                    status = 1
                },
                new Buku
                {
                    id = 2,
                    judul = "Indonesiaku",
                    penulis = "Prasetyo Yono",
                    penerbit = "XYZ Publications",
                    issn = "5687-1585",
                    tahun = 2018,
                    status = 1
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            return View(bukus); // Mengirimkan list bukus ke tampilan Index.cshtml
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Buku buku)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (bukus.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                buku.id = new_id;
                buku.status = 1;

                bukus.Add(buku); // Menambahkan buku baru ke list bukus
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(buku);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus buku." };

            try
            {
                var buku = bukus.FirstOrDefault(b => b.id == id);
                if(buku != null)
                {
                    bukus.Remove(buku);
                    response = new
                    {
                        success = true,
                        message = "Buku berhasil dihapus"
                    };
                }
                else
                {
                    response = new
                    {
                        success = false,
                        message = "Buku Tidak Ditemukan !"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Buku buku = bukus.FirstOrDefault(b => b.id == id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        [HttpPost]
        public IActionResult Edit(Buku buku)
        {
            if (ModelState.IsValid)
            {
                Buku newBuku = bukus.FirstOrDefault(b=>b.id == buku.id);
                if(newBuku == null)
                {
                    return NotFound();
                }

                newBuku.judul = buku.judul;
                newBuku.penulis = buku.penulis;
                newBuku.penerbit = buku.penerbit;
                newBuku.issn = buku.issn;
                newBuku.tahun = buku.tahun;

                TempData["SuccessMessage"] = "Buku Berhasil DiUpdate.";
                return RedirectToAction("Index");
            }
            return View(buku);
        }
    }
}
