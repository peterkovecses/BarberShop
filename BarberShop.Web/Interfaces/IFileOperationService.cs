using BarberShop.Bll.DTOs;
using BarberShop.Web.Enums;
using System.Threading.Tasks;

namespace BarberShop.Web.Interfaces
{
    public interface IFileOperationService
    {
        public Task<(string, FileErrorType?)> SaveFileAsync(BarberDTO barber);
    }
}
