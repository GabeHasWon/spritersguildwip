﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using spritersguildwip.Ability;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace spritersguildwip.NPCs.Hostile
{
    class CrystalClumpEnemy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Observer");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 14;
            npc.width = 58;
            npc.height = 86;

            npc.damage = 15;
            npc.defense = 15;
            npc.lifeMax = 90;
            npc.knockBackResist = 0.2f;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;

            npc.value = 111f;
        }

        int SuckTime { get => (int)npc.ai[0]; set => npc.ai[0] = value; }
        bool CanSuck => SuckTime > 0;
        Player Target => Main.player[npc.target];
        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 41); //granite golem
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 30); //ice materialize
            if (npc.life <= 0)
            {
                Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 5); //ice/pixie
                Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 34); //deadly sphere
            }
            else
            {

                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 50); //ice block mine
            }
            base.HitEffect(hitDirection, damage);
        }

        public override void AI()
        {
            void SpawnDust(float speed)
            {
                Vector2 dustPos = npc.Center + Main.rand.NextVector2CircularEdge(180, 180);
                Dust.NewDustPerfect(dustPos, mod.DustType("Air"), 
                    (dustPos - npc.Center).SafeNormalize(Vector2.Zero) /* Use SafeNormalize to prevent nasty DB0 errors. */ * -speed, 
                    0, default, 0.6f);
            }

            npc.TargetClosest(true);

            /* Using the sign of SuckTime as a boolean, kindof. 
             * When the Observer has pulled for more than 180 ticks, it'll set its SuckTime to -180.
             * Since it's negative, it won't suck and won't decrease.
             * While it's cooling down (SuckTime < 0), it will constantly approach being ready to suck (increasing SuckTime).
             */

            if (SuckTime > 180)
                SuckTime = -180;

            if (SuckTime <= 0)
            {
                SuckTime++;
                return; // Don't run any more code if cooling down!
            }

            if (Main.rand.NextBool())
            {
                SpawnDust(2);
            }
            for (int k = 0; k <= 200; k += 1)
            {
                NPC wisp = Main.npc[k];
                Vector2 wispDistance = wisp.Center - npc.Center;
                if (wisp.type == mod.NPCType("DesertWisp") || wisp.type == mod.NPCType("DesertWisp2"))
                {
                    if (wispDistance.Length() <= 240 && CanSuck)
                    {
                        wisp.velocity = (npc.Center - wisp.Center).SafeNormalize(Vector2.Zero) * 7;
                        wisp.localAI[2] += 5;
                    }
                    if (npc.Hitbox.Intersects(wisp.Hitbox))
                    {
                        Helper.Kill(wisp);
                    }
                }
            }
            if (Vector2.Distance(npc.Center, Target.Center) <= 180)
            {
                npc.velocity = Vector2.Zero;
                Target.velocity = (npc.Center - Target.Center).SafeNormalize(Vector2.Zero) * 5;
                if (SuckTime % 20 == 0)
                    for (float k = 0; k <= Math.PI * 2; k += (float)Math.PI / 40)
                        if (Main.rand.Next(2) == 0)
                            SpawnDust(3);
                SuckTime++;
            }
        }
        public override void FindFrame(int frameHeight) => npc.frame.Y = (CanSuck ? 0 : 1) * frameHeight;
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            AbilityHandler mp = target.GetModPlayer<AbilityHandler>();
            if(mp.dashcd == 1)
            {
                target.immune = true;
                target.immuneTime = 5;
            }
        }
    }
    class CrystalClumpEnemy2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Crystal Observer");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 14;
            npc.width = 94;
            npc.height = 124;

            npc.damage = 50;
            npc.defense = 50;
            npc.lifeMax = 6000;
            npc.knockBackResist = 0f;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;

            npc.value = 82000f;
        }

        int SuckTime { get => (int)npc.ai[0]; set => npc.ai[0] = value; }
        int ShootTime { get => (int)npc.ai[1]; set => npc.ai[1] = value; }
        bool CanSuck => SuckTime > 0;
        bool HasSucked = false;
        Player Target => Main.player[npc.target];
        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 41); //granite golem
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 30); //ice materialize
            if (npc.life <= 0)
            {
                Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 5); //ice/pixie
                Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 34); //deadly sphere
            }
            else
            {

                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 50); //ice block mine
            }
            base.HitEffect(hitDirection, damage);
        }

        public override void AI()
        {
            void SpawnDust(float speed)
            {
                Vector2 dustPos = npc.Center + Main.rand.NextVector2CircularEdge(240, 240);
                Dust.NewDustPerfect(dustPos, mod.DustType("Air"),
                    (dustPos - npc.Center).SafeNormalize(Vector2.Zero) /* Use SafeNormalize to prevent nasty DB0 errors. */ * -speed,
                    0, default, 0.6f);
            }

            npc.TargetClosest(true);

            /* Using the sign of SuckTime as a boolean, kindof. 
             * When the Observer has pulled for more than 180 ticks, it'll set its SuckTime to -180.
             * Since it's negative, it won't suck and won't decrease.
             * While it's cooling down (SuckTime < 0), it will constantly approach being ready to suck (increasing SuckTime).
             */
            ShootTime += 1;
            if (ShootTime >= 460)
            {
                ShootTime = 0 + Main.rand.Next(20, 120);
            }
            if (SuckTime > 360)
                SuckTime = -180;

            npc.rotation = npc.velocity.X / 30f;

            if (SuckTime <= 0)
            {
                HasSucked = false;
                SuckTime++;
                return; // Don't run any more code if cooling down!
            }
            if (Main.rand.NextBool())
            {
                SpawnDust(2);
            }
            for (int k = 0; k <= 200; k += 1)
            {
                NPC wisp = Main.npc[k];
                Vector2 wispDistance = wisp.Center - npc.Center;
                if (wisp.type == mod.NPCType("DesertWisp") || wisp.type == mod.NPCType("DesertWisp2"))
                {
                    if (wispDistance.Length() <= 240 && CanSuck)
                    {
                        wisp.velocity = (npc.Center - wisp.Center).SafeNormalize(Vector2.Zero) * 14;
                        wisp.localAI[2] += 5;
                    }
                    if (npc.Hitbox.Intersects(wisp.Hitbox))
                    {
                        Helper.Kill(wisp);
                    }
                }
            }
            if (Vector2.Distance(npc.Center, Target.Center) <= 240)
            {
                HasSucked = true;
                npc.rotation = 0f;
                npc.velocity = Vector2.Zero;
                Target.velocity = (npc.Center - Target.Center).SafeNormalize(Vector2.Zero) * 8;
                if (SuckTime % 20 == 0)
                    for (float k = 0; k <= Math.PI * 2; k += (float)Math.PI / 40)
                        if (Main.rand.Next(2) == 0)
                            SpawnDust(4);
                SuckTime++;
            }
            else if (HasSucked)
            {
                npc.velocity *= 1.01f;
                ShootTime += 2;
                SuckTime++;
                SpawnDust(2);
            }
        }
        public override void FindFrame(int frameHeight) => npc.frame.Y = (CanSuck ? 0 : 1) * frameHeight;
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            AbilityHandler mp = target.GetModPlayer<AbilityHandler>();
            if (mp.dashcd == 1)
            {
                target.immune = true;
                target.immuneTime = 5;
            }
        }
    }
}
