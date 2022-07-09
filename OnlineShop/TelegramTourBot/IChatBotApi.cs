namespace TelegramTourBot
{
    public interface IChatBotApi
    {
        void Init();

        event ChatBotAPI.MessageReceivedEventHandler MessageReceive;
        void SendContactRequest(long chatId);

        void SendKeyboard(long chatId, string text);
    }
}
