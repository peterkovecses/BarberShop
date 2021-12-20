using BarberShop.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IServiceTypeService
    {
        public Task<IList<ServiceTypeDTO>> GetServiceTypesAsync();

        public Task<ServiceTypeDTO> GetServiceTypeAsync(int id);

        public Task AddOrUpdateServiceTypeAsync(ServiceTypeDTO serviceTypeDTO);

        public void DeleteServiceType(int id);
    }
}
