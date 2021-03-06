using java.util;

namespace CraftyServer.Core
{
    public class BlockSnow : Block
    {
        protected internal BlockSnow(int i, int j)
            : base(i, j, Material.snow)
        {
            setBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.125F, 1.0F);
            setTickOnLoad(true);
        }

        public override AxisAlignedBB getCollisionBoundingBoxFromPool(World world, int i, int j, int k)
        {
            return null;
        }

        public override bool isOpaqueCube()
        {
            return false;
        }

        public override bool canPlaceBlockAt(World world, int i, int j, int k)
        {
            int l = world.getBlockId(i, j - 1, k);
            if (l == 0 || !blocksList[l].isOpaqueCube())
            {
                return false;
            }
            else
            {
                return world.getBlockMaterial(i, j - 1, k).getIsSolid();
            }
        }

        public override void onNeighborBlockChange(World world, int i, int j, int k, int l)
        {
            func_275_g(world, i, j, k);
        }

        private bool func_275_g(World world, int i, int j, int k)
        {
            if (!canPlaceBlockAt(world, i, j, k))
            {
                dropBlockAsItem(world, i, j, k, world.getBlockMetadata(i, j, k));
                world.setBlockWithNotify(i, j, k, 0);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void harvestBlock(World world, int i, int j, int k, int l)
        {
            int i1 = Item.snowball.shiftedIndex;
            float f = 0.7F;
            double d = (world.rand.nextFloat()*f) + (1.0F - f)*0.5D;
            double d1 = (world.rand.nextFloat()*f) + (1.0F - f)*0.5D;
            double d2 = (world.rand.nextFloat()*f) + (1.0F - f)*0.5D;
            var entityitem = new EntityItem(world, i + d, j + d1, k + d2,
                                            new ItemStack(i1, 1, 0));
            entityitem.delayBeforeCanPickup = 10;
            world.entityJoinedWorld(entityitem);
            world.setBlockWithNotify(i, j, k, 0);
        }

        public override int idDropped(int i, Random random)
        {
            return Item.snowball.shiftedIndex;
        }

        public override int quantityDropped(Random random)
        {
            return 0;
        }

        public override void updateTick(World world, int i, int j, int k, Random random)
        {
            if (world.getSavedLightValue(EnumSkyBlock.Block, i, j, k) > 11)
            {
                dropBlockAsItem(world, i, j, k, world.getBlockMetadata(i, j, k));
                world.setBlockWithNotify(i, j, k, 0);
            }
        }

        public override bool shouldSideBeRendered(IBlockAccess iblockaccess, int i, int j, int k, int l)
        {
            Material material = iblockaccess.getBlockMaterial(i, j, k);
            if (l == 1)
            {
                return true;
            }
            if (material == blockMaterial)
            {
                return false;
            }
            else
            {
                return base.shouldSideBeRendered(iblockaccess, i, j, k, l);
            }
        }
    }
}