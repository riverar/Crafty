namespace CraftyServer.Core
{
    public class MaterialTransparent : Material
    {
        public override bool isSolid()
        {
            return false;
        }

        public override bool getCanBlockGrass()
        {
            return false;
        }

        public override bool getIsSolid()
        {
            return false;
        }
    }
}