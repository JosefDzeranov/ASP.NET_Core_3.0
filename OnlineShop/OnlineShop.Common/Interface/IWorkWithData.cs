namespace OnlineShop.Common.Interface
{
    public interface IWorkWithData
    {
        public void Write<T>(T TObject);

        public T Read<T>() where T : new();
    }
}
