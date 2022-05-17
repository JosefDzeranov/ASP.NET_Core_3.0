namespace OnlineShopWebApp.Interfase
{
    public interface IWorkWithData
    {
        public void Write<T>(T TObject);

        public T Read<T>() where T : new();
    }
}
