namespace CraftyServer.Core
{
    public class ItemLog : ItemBlock
    {
        public ItemLog(int i)
            : base(i)
        {
            setMaxDamage(0);
            setHasSubtypes(true);
        }

        public override int getMetadata(int i)
        {
            return i;
        }
    }
}