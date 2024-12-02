using KiemTra.Models;
using KiemTra.Repository;

namespace KiemTra.Repository
{
    public class TranDauRepository : ITranDauRepository
    {

           private readonly QlgiaiBongDaContext _context;
           public TranDauRepository(QlgiaiBongDaContext context)
            {
                _context = context;
           }
        public Trandau Add(Trandau trandau)
        {
            _context.Trandaus.Add(trandau);
            _context.SaveChanges();
             return trandau;        
        }

            public Trandau Delete(string trandauid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trandau> GetAll()
        {
            return _context.Trandaus;
        }

        public Trandau GetTranDau(string trandauid)
        {
            return _context.Trandaus.Find(trandauid);
        }

        public Trandau Update(Trandau trandau)
        {
            _context.Update(trandau);
            _context.SaveChanges();
            return trandau;
        }
    }
}
