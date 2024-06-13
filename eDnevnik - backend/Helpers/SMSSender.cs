using Vonage;
using Vonage.Request;

namespace eDnevnik___backend.Helpers;

public class SMSSender
{
    private readonly IConfiguration _vonageSettings;

    public SMSSender()
    {
        _vonageSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        _vonageSettings = _vonageSettings.GetSection("VonageSettings");
    }

    public bool SendSMS(string phoneNumber, string verificationToken)
    {
        var credentials = Credentials.FromApiKeyAndSecret(
            _vonageSettings["ApiKey"],
            _vonageSettings["ApiSecret"]
        );

        var vonageClient = new VonageClient(credentials);

        try
        {
            var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = phoneNumber,
                From = "Vonage APIs",
                Text = $"You login code is: {verificationToken}"
            });

            if (response.Messages[0].Status == 0.ToString())
            {
                Console.WriteLine(response.Messages[0].ErrorText);
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return false;
    }
}