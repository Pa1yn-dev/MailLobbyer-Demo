namespace MailLobbyer.SmtpClientSettingsClass
{
    public class SmtpClientSettings
    {
        public string? Sendername { get; set; }
        public string? Senderemail { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    

    public SmtpClientSettings(string sendername, string senderemail, string username, string password, string host, int port)
    {
        Sendername = sendername;
        Senderemail = senderemail;
        Username = username;
        Password = password;
        Host = host;
        Port = port;

    }
    }
}
