﻿
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace StarlightRiver.Dusts
{
    public class Gas : ModDust
    {
        int timer;
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            timer = 30;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return dust.color;
        }
        
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity * 0.1f;
            //dust.color *= 0.982f;
            dust.scale *= 0.982f;
            dust.velocity *= 0.97f;
            dust.rotation += 0.1f;

            if (dust.scale <= 0.2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
