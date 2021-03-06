﻿using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using spritersguildwip.Ability;
using Terraria;
using Terraria.ModLoader;
using spritersguildwip.Items.Vitric;

namespace spritersguildwip.Tiles
{
    class GlassCrystal : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileLighted[Type] = true;
            TileID.Sets.DrawsWalls[Type] = true;
            drop = mod.ItemType("Sandglass2");
            AddMapEntry(new Color(172, 131, 105));
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (Main.rand.Next(30) == 0)
            {
                Dust.NewDustPerfect(new Vector2(i * 16, j * 16), mod.DustType("Air"), Vector2.Zero);
            }
        }
    }
}
