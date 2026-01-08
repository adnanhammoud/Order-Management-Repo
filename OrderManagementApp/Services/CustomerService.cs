namespace OrderManagementApp.Services;

public class CustomerService
{
    private AppDbContext _dbContext;

    public CustomerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
}