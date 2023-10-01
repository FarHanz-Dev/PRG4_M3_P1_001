using Microsoft.AspNetCore.Mvc;
using PRG4_M3_P1_001.Models;

namespace PRG4_M3_P1_001.Controllers
{
    public class AnggotaController : Controller
    {
        private static List<Anggota> anggotas = InitializeData(); // Inisialisasi list bukus dengan data awal
        public IActionResult Index()
        {
            return View(anggotas);
        }

        
        private static List<Anggota> InitializeData()
        {
            List<Anggota> initialData = new List<Anggota>
            {
                new Anggota
                {
                    id = 1,
                    Nama = "Nayu",
                    Umur = 18,
                    Alamat = "Telukjambe Barat, Karawang",
                    NoHp = "08596984487"
                },
                new Anggota
                {
                    id = 2,
                    Nama = "Iswandi",
                    Umur = 20,
                    Alamat = "Telukjambe Timur, Karawang",
                    NoHp = "0859674787"

                }
            };
            return initialData;
        }

       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (anggotas.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                anggota.id = new_id;

                anggotas.Add(anggota); // Menambahkan buku baru ke list bukus
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus anggota." };

            try
            {
                var anggota = anggotas.FirstOrDefault(b => b.id == id);
                if (anggota != null)
                {
                    anggotas.Remove(anggota);
                    response = new
                    {
                        success = true,
                        message = "Anggota berhasil dihapus"
                    };
                }
                else
                {
                    response = new
                    {
                        success = false,
                        message = "Anggota Tidak Ditemukan !"
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
            Anggota anggota = anggotas.FirstOrDefault(b => b.id == id);
            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        [HttpPost]
        public IActionResult Edit(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                Anggota newAnggota = anggotas.FirstOrDefault(b => b.id == anggota.id);
                if (newAnggota == null)
                {
                    return NotFound();
                }

                newAnggota.Nama = anggota.Nama;
                newAnggota.Umur = anggota.Umur;
                newAnggota.Alamat = anggota.Alamat;
                newAnggota.NoHp = anggota.NoHp;
         

                TempData["SuccessMessage"] = "Buku Berhasil DiUpdate.";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }
    }
}
