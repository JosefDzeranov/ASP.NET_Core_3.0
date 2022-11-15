
namespace TelegramTourBot
{
    public interface IChatBotApi
    {
        void Init();

        void SendContactRequest(long chatId);
        void SendWelcomeMessage(long chatId, string firstName);

        void SendResponse(long chatId, string text);

        void SendKeyboard(long chatId, string text);

    }
}
