using BarberShop.Bll.DTOs;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IAppUserService
    {
        public Task AddBarberUserAsync(BarberUserDTO barberUserDTO);

        public Task<BarberUserDTO> GetBarberUserAsync(int barberId);

        public Task<int> GetBarberIdByAppUserIdAsync(int appUserId);
    }
}
