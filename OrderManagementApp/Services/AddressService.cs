using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Services;

public class AddressService
{
    private AppDbContext _dbContext;

    public AddressService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateAddress(AddressDTO address)
    {
        var _address = new Address()
        {
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City,
            CountryCode = address.CountryCode,
            State = address.State,
        };
        _dbContext.Add(_address);
        _dbContext.SaveChanges();
    }

    public AddressDTO GetAddressById(int addressId)
    {
        var _address = _dbContext.Addresses.Where(a => a.Id == addressId).Select(ad => new AddressDTO()
        {
            Line1 = ad.Line1,
            Line2 = ad.Line2,
            City = ad.City,
            CountryCode = ad.CountryCode,
            State = ad.State,
        }).FirstOrDefault();
        
        return _address;
    }
}