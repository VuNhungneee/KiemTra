using KiemTra.Models;

namespace KiemTra.Repository
{
    public interface ITranDauRepository
    {
        Trandau Add(Trandau trandau);
		Trandau Update(Trandau trandau);
		Trandau Delete(String trandauid);
		Trandau GetTranDau(String trandauid);
        IEnumerable<Trandau> GetAll();
    }
}
