namespace CraftyServer.Core
{
    public class ShapedRecipes
        : IRecipe
    {
        private readonly int field_21140_b;
        private readonly ItemStack field_21142_e;
        private readonly ItemStack[] field_21143_d;
        private readonly int field_21144_c;
        public int field_21141_a;

        public ShapedRecipes(int i, int j, ItemStack[] aitemstack, ItemStack itemstack)
        {
            field_21141_a = itemstack.itemID;
            field_21140_b = i;
            field_21144_c = j;
            field_21143_d = aitemstack;
            field_21142_e = itemstack;
        }

        #region IRecipe Members

        public bool func_21134_a(InventoryCrafting inventorycrafting)
        {
            for (int i = 0; i <= 3 - field_21140_b; i++)
            {
                for (int j = 0; j <= 3 - field_21144_c; j++)
                {
                    if (func_21139_a(inventorycrafting, i, j, true))
                    {
                        return true;
                    }
                    if (func_21139_a(inventorycrafting, i, j, false))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public ItemStack func_21136_b(InventoryCrafting inventorycrafting)
        {
            return new ItemStack(field_21142_e.itemID, field_21142_e.stackSize, field_21142_e.getItemDamage());
        }

        public int getRecipeSize()
        {
            return field_21140_b*field_21144_c;
        }

        #endregion

        private bool func_21139_a(InventoryCrafting inventorycrafting, int i, int j, bool flag)
        {
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    int i1 = k - i;
                    int j1 = l - j;
                    ItemStack itemstack = null;
                    if (i1 >= 0 && j1 >= 0 && i1 < field_21140_b && j1 < field_21144_c)
                    {
                        if (flag)
                        {
                            itemstack = field_21143_d[(field_21140_b - i1 - 1) + j1*field_21140_b];
                        }
                        else
                        {
                            itemstack = field_21143_d[i1 + j1*field_21140_b];
                        }
                    }
                    ItemStack itemstack1 = inventorycrafting.func_21084_a(k, l);
                    if (itemstack1 == null && itemstack == null)
                    {
                        continue;
                    }
                    if (itemstack1 == null && itemstack != null || itemstack1 != null && itemstack == null)
                    {
                        return false;
                    }
                    if (itemstack.itemID != itemstack1.itemID)
                    {
                        return false;
                    }
                    if (itemstack.getItemDamage() != -1 && itemstack.getItemDamage() != itemstack1.getItemDamage())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}