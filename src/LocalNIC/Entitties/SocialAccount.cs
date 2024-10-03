namespace Waqfi.LocalNIC.Entities;

public class SocialAccount
{
    public string? Twitter { get;  set; }
    public string? Instgram { get;  set; }
    public string? TickTok { get;  set; }
    public string? Youtube { get;  set; }
    public string? Snapchat { get;  set; }
    public Guid Id { get;  set; }
    public Guid SocityId { get; set; }
    public Society? Society { get; set; }

    SocialAccount()
    {
        Id = Guid.NewGuid();
    }

    internal SocialAccount(string twitter, string instgram, string tickTok, string youtube, string snapchat) : this()
    {
        Twitter = twitter;
        Instgram = instgram;
        TickTok = tickTok;
        Youtube = youtube;
        Snapchat = snapchat;
    }

    internal void Update(string twitter, string instgram, string tickTok, string youtube, string snapchat)
    {
        Twitter = twitter;
        Instgram = instgram;
        TickTok = tickTok;
        Youtube = youtube;
        Snapchat = snapchat;
    }
}