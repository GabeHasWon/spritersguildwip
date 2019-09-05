﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace spritersguildwip.Items.Vitric
{
    class VitricPick : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 14;
            item.useAnimation = 22;
            item.pick = 85;
            item.useStyle = 1;
            item.knockBack = 0.5f;
            item.value = 1000;
            item.rare = 2;
            item.autoReuse = true;
            item.UseSound = SoundID.Item18;
            item.useTurn = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vitreous Pickaxe");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Vitric.OverseerCore>());
            recipe.AddIngredient(mod.ItemType<Items.Vitric.VitricBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

}