using gwp.Models;

namespace gwp.Repositories
{
    public interface ILobRepository
    {
        public List<double> GetLobItems(string country, string lob);
    }
}
