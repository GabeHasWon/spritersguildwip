﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace spritersguildwip.Projectiles.WeaponProjectiles
{
    class VitricSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.tileCollide = false;
            projectile.ignoreWater = false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Glass");
        }

        float f = 1;
        public override void AI()
        {
            f += 0.1f;
            Player player = Main.player[projectile.owner];
            projectile.position += Vector2.Normalize(player.Center - projectile.Center) * f;
            projectile.velocity *= 0.94f;
            projectile.rotation = (player.Center - projectile.Center).Length() * 0.1f;

            if((player.Center - projectile.Center).Length() <= 32 && projectile.timeLeft < 110)
            {
                projectile.timeLeft = 0;
            }
        }
    }
}
