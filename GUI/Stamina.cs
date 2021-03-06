﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using spritersguildwip.Ability;

namespace spritersguildwip.GUI
{
    public class Stamina : UIState
    {
        public UIPanel abicon;
        public static bool visible = false;

        Stam Stam1 = new Stam(ModContent.GetTexture("spritersguildwip/GUI/Stamina2"));
        Stam Stam2 = new Stam(ModContent.GetTexture("spritersguildwip/GUI/Stamina"));
        public override void OnInitialize()
        {
            Stam1.Left.Set(-303, 1);
            Stam1.Top.Set(110, 0);
            Stam1.Width.Set(22, 0f);
            Stam1.Height.Set(0, 0f);
            base.Append(Stam1);

            Stam2.Left.Set(0, 0);
            Stam2.Top.Set(0, 0);
            Stam2.Width.Set(22, 0f);
            Stam2.Height.Set(0, 0f);
            Stam1.Append(Stam2);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            AbilityHandler mp = player.GetModPlayer<AbilityHandler>();
            //Stam1.Copies = mp.staminamax;
            //Stam2.Copies = mp.stamina;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Recalculate();
        }
        
    }

    class Stam : UIElement
    {
        public Texture2D Texture;

        public Stam(Texture2D texture)
        {
            Texture = texture;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(Texture, new Rectangle((int)dimensions.X, (int)dimensions.Y, (int)dimensions.Width, (int)dimensions.Height), Color.White);           
        }
    }
}
  