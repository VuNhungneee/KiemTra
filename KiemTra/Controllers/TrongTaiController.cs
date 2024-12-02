using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KiemTra.Models;
using KiemTra.Models.TrongTaiTheoTranDauModel;
namespace KiemTra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrongTaiController : ControllerBase
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        [HttpGet]
        public IEnumerable<TrongTaiTheoTranDau> GetAllTrongTai()
        {
            var cauthu = (from td in db.Trandaus
                            join s in db.TrandauCauthus on td.TranDauId equals s.TranDauId
                            join ct in db.Cauthus on s.CauThuId equals ct.CauThuId
                            select new TrongTaiTheoTranDau
            {
                CauThuId = ct.CauThuId,
                TranDauId = td.TranDauId,
                HoVaTen = ct.HoVaTen,
                ViTri = ct.ViTri,
                Anh = ct.Anh

            }).ToList();
            return cauthu;
        }
        [HttpGet("{trandauid}")]
        public IEnumerable<TrongTaiTheoTranDau> GetAllTrongTaiByTranDau(String trandauid)
        {
            var cauthu = (from td in db.Trandaus
                          join s in db.TrandauCauthus on td.TranDauId equals s.TranDauId
                          join ct in db.Cauthus on s.CauThuId equals ct.CauThuId
                          where td.TranDauId == trandauid
                          select new TrongTaiTheoTranDau
                          {
                              CauThuId = ct.CauThuId,
                              TranDauId = td.TranDauId,
                              HoVaTen = ct.HoVaTen,
                              ViTri = ct.ViTri,
                              Anh = ct.Anh

                          }).ToList();
            return cauthu;
        }
    }
}
