using InternetShopApp.Domain.Entities;
//using InternetShopApp.Data.Entities;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Data.Repositories.Interfaces;

namespace InternetShopApp.Services
{
    public class StockService : GenericService<Stock>, IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository) : base(stockRepository)
        {
            _stockRepository = stockRepository;
        }
    }
}

