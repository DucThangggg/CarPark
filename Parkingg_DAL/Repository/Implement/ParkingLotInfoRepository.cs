using Microsoft.EntityFrameworkCore;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public class ParkingLotInfoRepository : IParkingLotInfoRepository
    {
        private readonly MyDbContext _context;
        public ParkingLotInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddParkingLot(ParkingLot_Entities parking_Entities)
        {
            _context.parkingLot_Entities.Add(parking_Entities);
        }

        public async Task<IEnumerable<ParkingLot_Entities>> GetParkingLotList_Entities()
        {
            // Get Parking ( một List)
            return await _context.parkingLot_Entities.ToListAsync();
        }
        // Từ ParkName suy ra IDPark
        public async Task<ParkingLot_Entities> FindParkingWithName_Entities(string parkName)
        {
            // Từ ParkName trả về một ParkingLot_Entities
            var _parkingEntites = await _context.parkingLot_Entities.Include(x => x.ListCar).FirstOrDefaultAsync(p => p.ParkName == parkName);
            return _parkingEntites;
        }
        // Delete ParkingLot
        public async Task DeleteParkingLotName(string parkName)
        {
            // Trả về một Object Entities
            var _deleteparking = await _context.parkingLot_Entities.FirstOrDefaultAsync(p => p.ParkName == parkName);
            if (_deleteparking != null)
            {
                _context.parkingLot_Entities.Remove(_deleteparking);
            }
        }
    }
}
