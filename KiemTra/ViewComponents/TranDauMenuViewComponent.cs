using KiemTra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KiemTra.ViewComponents
{
    public class TranDauMenuViewComponent: ViewComponent
    {
        private readonly ITranDauRepository _tranDauRepository;
        public TranDauMenuViewComponent(ITranDauRepository tranDauRepository)
        {
            _tranDauRepository = tranDauRepository;
        }
        public IViewComponentResult Invoke()
        {
            var trandau = _tranDauRepository.GetAll().OrderBy(x => x.TranDauId);
            return View(trandau);
        }
    }
}
