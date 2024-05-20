namespace ServersLibrary
{
    public sealed class Servers
    {
        private static readonly Servers instance = new Servers();
        private readonly List<string> serverList = new List<string>();
        private readonly object lockObject = new object();

        private Servers() { }

        public static Servers Instance
        {
            get
            {
                return instance;
            }
        }

        public bool AddServer(string server)
        {
            if (string.IsNullOrWhiteSpace(server) || !server.StartsWith("http://") && !server.StartsWith("https://"))
            {
                return false;
            }

            lock (lockObject)
            {
                if (serverList.Contains(server))
                {
                    return false;
                }

                serverList.Add(server);
            }

            return true;
        }

        public List<string> GetHttpServers()
        {
            var httpServers = new List<string>();

            lock (lockObject)
            {
                foreach (var server in serverList)
                {
                    if (server.StartsWith("http://"))
                    {
                        httpServers.Add(server);
                    }
                }
            }

            return httpServers;
        }

        public List<string> GetHttpsServers()
        {
            var httpsServers = new List<string>();

            lock (lockObject)
            {
                foreach (var server in serverList)
                {
                    if (server.StartsWith("https://"))
                    {
                        httpsServers.Add(server);
                    }
                }
            }

            return httpsServers;
        }
    }

}