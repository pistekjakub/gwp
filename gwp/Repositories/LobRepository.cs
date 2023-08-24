using gwp.Models.Database;

namespace gwp.Repositories
{
    public class LobRepository : ILobRepository
    {
        private readonly MockDatabase _database;

        public LobRepository(MockDatabase database)
        {
            _database = database;
        }

        public List<double> GetLobItems(string country, string lob)
        {
            var record = _database.Records.FirstOrDefault(c => c.Country == country && c.Lob == lob);
            if (record == null) 
            {
                throw new KeyNotFoundException($"There is no record for name ${lob} in country ${country}");
            }

            return new List<double> { record.Y2000, record.Y2001, record.Y2002, record.Y2003, 
                                  record.Y2004, record.Y2005, record.Y2006, record.Y2007, 
                                  record.Y2008, record.Y2009, record.Y2010, record.Y2011, 
                                  record.Y2012, record.Y2013, record.Y2014, record.Y2015 };
        }

    }
}
