using gwp.Repositories;

namespace gwp.Services
{
    public class AvgService : IAvgService
    {
        private const int _numberOfYears = 16;

        private readonly ILobRepository _avgRepository;
        private readonly ICacheService _cacheService;

        public AvgService(ILobRepository avgRepository, ICacheService cacheService)
        {
            _avgRepository = avgRepository;
            _cacheService = cacheService;
        }

        public Dictionary<string, double> GetAvgItems(string country, List<string> lobs)
        {
            var result = new Dictionary<string, double>();
            foreach (var lob in lobs)             
            {
                var cacheKey = $"{country}_{lob}";
                var averagePrice = _cacheService.GetValue<double?>(cacheKey);
                if (averagePrice is null) 
                {
                    averagePrice = _avgRepository.GetLobItems(country, lob).ToList().Sum() / _numberOfYears;
                    _cacheService.SetValue(cacheKey, averagePrice);
                }
                result.Add(lob, averagePrice.Value);
            }
            return result;
        }
    }
}
