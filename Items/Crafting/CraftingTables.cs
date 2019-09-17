﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace StarlightRiver.Items.Crafting
{
    public class Oven : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oven");
            Tooltip.SetDefault("Used to bake items");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("Oven");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class AstralForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Forge");
            Tooltip.SetDefault("Used to harness the power of the stars");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("AstralForge");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<AstralOre>(), 10);
            recipe.AddIngredient(ItemID.Hellforge, 1);
            recipe.AddIngredient(mod.ItemType<StardustSoul>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<AstralOre>(), 5);
            recipe.AddIngredient(mod.ItemType<StardustSoul>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(mod.ItemType<AstralBar>());
            recipe.AddRecipe();
        }
    }
    public class HerbStation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Herbologist's Bench");
            Tooltip.SetDefault("Used to refine herbs");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("HerbStation");
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(mod.ItemType<Herbology.Ivy>());
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}