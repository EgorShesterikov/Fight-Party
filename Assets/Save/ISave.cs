namespace FightParty.Save
{
    public interface ISave<T>
    {
        void Save(T info);
        T Load();
    }
}