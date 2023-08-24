using gwp.Models;

namespace gwp.Services
{
    public interface IAvgService
    {
        public Dictionary<string, double> GetAvgItems(string country, List<string> lobs);
    }
}
