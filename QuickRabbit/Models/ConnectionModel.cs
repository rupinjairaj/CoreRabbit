namespace QuickRabbit.Models
{
    class ConnectionModel
    {
        public int Port { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VHost { get; set; }
    }
}