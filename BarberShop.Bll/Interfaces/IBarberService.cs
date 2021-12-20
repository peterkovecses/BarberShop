using BarberShop.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IBarberService
    {
        public Task<IList<BarberDTO>> GetBarbersAsync();

        public Task<BarberDTO> GetBarberAsync(int id);

        public Task AddOrUpdateBarberAsync(BarberDTO barberDTO);

        public Task DeleteBarberAsync(int id);
    }
}
