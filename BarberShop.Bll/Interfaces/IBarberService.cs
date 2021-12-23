using BarberShop.Bll.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IBarberService
    {
        public Task<IList<BarberDTO>> GetBarbersAsync();

        public Task<BarberDTO> GetBarberAsync(int id);        

        public Task<int> AddBarberAsync(BarberUserDTO barberUserDTO);

        public Task UpdateBarberAsync(BarberDTO barberDTO);

        public Task DeleteBarberAsync(int id);
    }
}
