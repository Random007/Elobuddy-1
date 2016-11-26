using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;

namespace Lib
{
    public class Cache
    {
        public List<GameObject> AllObjects { get; }

        public List<GameObject> AllyObjects { get; }
        public List<GameObject> EnemyObjects { get; }

        public List<Obj_AI_Base> AllEnemies { get; }
        public List<Obj_AI_Base> AllAllies { get; }

        public List<AIHeroClient> AllHeroes { get; }
        public List<AIHeroClient> AllyHeroes { get; }
        public List<AIHeroClient> EnemyHeroes { get; }

        public List<Obj_AI_Minion> AllMinions { get; }
        public List<Obj_AI_Minion> EnemyMinions { get; }
        public List<Obj_AI_Minion> AllyMinions { get; }

        public List<Obj_AI_Minion> AllJungleMinions { get; }
        public List<Obj_AI_Minion> SmallJungleMinions { get; }
        public List<Obj_AI_Minion> LargeJungleMinions { get; }
        public List<Obj_AI_Minion> EpicJungleMinions { get; }
        public List<Obj_AI_Minion> LegendaryJungleMinions { get; }

        public List<Obj_AI_Minion> AllWards { get; }
        public List<Obj_AI_Minion> AllyWards { get; }
        public List<Obj_AI_Minion> EnemyWards { get; }

        public List<Obj_BarracksDampener> AllInhibitors { get; }
        public List<Obj_BarracksDampener> AllyInhibitors { get; }
        public List<Obj_BarracksDampener> EnemyInhibitors { get; }

        public List<Obj_Shop> AllShops { get; }
        public List<Obj_Shop> AllyShops { get; }
        public List<Obj_Shop> EnemyShops { get; }

        public List<Obj_SpawnPoint> AllSpawnPoints { get; }
        public List<Obj_SpawnPoint> AllySpawnPoints { get; }
        public List<Obj_SpawnPoint> EnemySpawnPoints { get; }

        public List<Obj_AI_Turret> AllTurrets { get; }
        public List<Obj_AI_Turret> AllyTurrets { get; }
        public List<Obj_AI_Turret> EnemyTurrets { get; }

        public List<Obj_HQ> AllNexus { get; }
        public Obj_HQ AllyNexus { get; private set; }
        public Obj_HQ EnemyNexus { get; private set; }

        public List<MissileClient> AllMissiles { get; }
        public List<MissileClient> AllyMissiles { get; }
        public List<MissileClient> EnemyMissiles { get; }

        public List<Obj_GeneralParticleEmitter> AllParticleEmitters { get; }

        public Cache()
        {
            #region Init Lists

            AllObjects = new List<GameObject>();
            AllyObjects = new List<GameObject>();
            EnemyObjects = new List<GameObject>();

            AllAllies = new List<Obj_AI_Base>();
            AllEnemies = new List<Obj_AI_Base>();

            AllHeroes = new List<AIHeroClient>();
            AllyHeroes = new List<AIHeroClient>();
            EnemyHeroes = new List<AIHeroClient>();

            AllMinions = new List<Obj_AI_Minion>();
            AllyMinions = new List<Obj_AI_Minion>();
            EnemyMinions = new List<Obj_AI_Minion>();

            AllJungleMinions = new List<Obj_AI_Minion>();
            SmallJungleMinions = new List<Obj_AI_Minion>();
            LargeJungleMinions = new List<Obj_AI_Minion>();
            EpicJungleMinions = new List<Obj_AI_Minion>();
            LegendaryJungleMinions = new List<Obj_AI_Minion>();

            AllWards = new List<Obj_AI_Minion>();
            AllyWards = new List<Obj_AI_Minion>();
            EnemyWards = new List<Obj_AI_Minion>();

            AllInhibitors = new List<Obj_BarracksDampener>();
            AllyInhibitors = new List<Obj_BarracksDampener>();
            EnemyInhibitors = new List<Obj_BarracksDampener>();

            AllShops = new List<Obj_Shop>();
            AllyShops = new List<Obj_Shop>();
            EnemyShops = new List<Obj_Shop>();

            AllSpawnPoints = new List<Obj_SpawnPoint>();
            AllySpawnPoints = new List<Obj_SpawnPoint>();
            EnemySpawnPoints = new List<Obj_SpawnPoint>();

            AllTurrets = new List<Obj_AI_Turret>();
            AllyTurrets = new List<Obj_AI_Turret>();
            EnemyTurrets = new List<Obj_AI_Turret>();

            AllNexus = new List<Obj_HQ>();

            AllMissiles = new List<MissileClient>();
            AllyMissiles = new List<MissileClient>();
            EnemyMissiles = new List<MissileClient>();

            AllParticleEmitters = new List<Obj_GeneralParticleEmitter>();

            #endregion Init Lists

            #region GameObjects

            AllObjects.AddRange(ObjectManager.Get<GameObject>().Where(o => o.IsValid));

            AllyObjects.AddRange(AllObjects.Where(o => o.IsAlly));
            EnemyObjects.AddRange(AllObjects.Where(o => o.IsEnemy));

            #endregion GameObjects

            #region Heroes

            AllHeroes.AddRange(ObjectManager.Get<AIHeroClient>());
            AllyHeroes.AddRange(AllHeroes.Where(o => o.IsAlly));
            EnemyHeroes.AddRange(AllHeroes.Where(o => o.IsEnemy));

            #endregion Heroes

            #region Minions

            AllMinions.AddRange(
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(
                        o => o.Team != GameObjectTeam.Neutral && !o.GetMinionType().HasFlag(Extensions.MinionTypes.Ward)));

            AllyMinions.AddRange(AllMinions.Where(o => o.IsAlly));
            EnemyMinions.AddRange(AllMinions.Where(o => o.IsEnemy));

            #region JungleMinions

            AllJungleMinions.AddRange(
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(
                        o =>
                            o.Team == GameObjectTeam.Neutral && !o.GetMinionType().HasFlag(Extensions.MinionTypes.Ward) &&
                            o.Name != "WardCorpse"));

            SmallJungleMinions.AddRange(
                AllJungleMinions.Where(o => o.GetJungleType() == Extensions.JungleType.Small));
            LargeJungleMinions.AddRange(
                AllJungleMinions.Where(o => o.GetJungleType() == Extensions.JungleType.Large));
            EpicJungleMinions.AddRange(
                AllJungleMinions.Where(o => o.GetJungleType() == Extensions.JungleType.Epic));
            LegendaryJungleMinions.AddRange(
                AllJungleMinions.Where(o => o.GetJungleType() == Extensions.JungleType.Legendary));

            #endregion JungleMinions

            #region Wards

            AllWards.AddRange(
                ObjectManager.Get<Obj_AI_Minion>().Where(o => o.GetMinionType().HasFlag(Extensions.MinionTypes.Ward)));

            AllyWards.AddRange(AllWards.Where(o => o.IsAlly));
            EnemyWards.AddRange(AllWards.Where(o => o.IsEnemy));

            #endregion Wards

            #endregion Minions

            #region Structures

            #region Turrets

            AllTurrets.AddRange(ObjectManager.Get<Obj_AI_Turret>());

            EnemyTurrets.AddRange(AllTurrets.Where(o => o.IsEnemy));
            AllyTurrets.AddRange(AllTurrets.Where(o => o.IsAlly));

            #endregion Turrets

            #region Inihibitors

            AllInhibitors.AddRange(ObjectManager.Get<Obj_BarracksDampener>());

            AllyInhibitors.AddRange(AllInhibitors.Where(o => o.IsAlly));
            EnemyInhibitors.AddRange(AllInhibitors.Where(o => o.IsEnemy));

            #endregion Inihibitors

            #region Shops

            AllShops.AddRange(ObjectManager.Get<Obj_Shop>());

            AllyShops.AddRange(AllShops.Where(o => o.IsAlly));
            EnemyShops.AddRange(AllShops.Where(o => o.IsEnemy));

            #endregion Shops

            #region SpawnPoints

            AllSpawnPoints.AddRange(ObjectManager.Get<Obj_SpawnPoint>());
            AllySpawnPoints.AddRange(AllSpawnPoints.Where(o => o.IsAlly));
            EnemySpawnPoints.AddRange(AllSpawnPoints.Where(o => o.IsEnemy));

            #endregion SpawnPoints

            #region Nexus

            AllNexus.AddRange(ObjectManager.Get<Obj_HQ>());

            AllyNexus = AllNexus.FirstOrDefault(o => o.IsAlly);
            EnemyNexus = AllNexus.FirstOrDefault(o => o.IsEnemy);

            #endregion Nexus

            #endregion Structures

            #region MissileClients

            AllMissiles.AddRange(ObjectManager.Get<MissileClient>());

            AllyMissiles.AddRange(AllMissiles.Where(o => o.IsAlly));
            EnemyMissiles.AddRange(AllMissiles.Where(o => o.IsEnemy));

            #endregion MissileClients

            #region ParticlesEmitters

            AllParticleEmitters.AddRange(ObjectManager.Get<Obj_GeneralParticleEmitter>());

            #endregion ParticlesEmitters

            //All Enemies & Allies
            AllEnemies.AddRange(EnemyHeroes.Cast<Obj_AI_Base>().Concat(EnemyMinions));
            AllEnemies.AddRange(AllJungleMinions);

            AllAllies.AddRange(AllyHeroes.Cast<Obj_AI_Base>().Concat(AllyMinions));

            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
        }

        private void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            AllObjects.Add(sender);

            var hero = sender as AIHeroClient;
            if (hero != null)
            {
                AllHeroes.Add(hero);
                if (hero.IsEnemy)
                {
                    EnemyHeroes.Add(hero);
                    AllEnemies.Add(hero);
                }
                else
                {
                    AllyHeroes.Add(hero);
                    AllAllies.Add(hero);
                }

                return;
            }

            var minion = sender as Obj_AI_Minion;
            if (minion != null)
            {
                if (minion.Team != GameObjectTeam.Neutral)
                {
                    if (minion.GetMinionType().HasFlag(Extensions.MinionTypes.Ward))
                    {
                        AllWards.Add(minion);
                        if (minion.IsEnemy)
                        {
                            EnemyWards.Add(minion);
                        }
                        else
                        {
                            AllyWards.Add(minion);
                        }
                    }
                    else
                    {
                        AllMinions.Add(minion);
                        if (minion.IsEnemy)
                        {
                            EnemyMinions.Add(minion);
                            AllEnemies.Add(minion);
                        }
                        else
                        {
                            AllyMinions.Add(minion);
                            AllAllies.Add(minion);
                        }
                    }
                }
                else if (minion.Name != "WardCorpse")
                {
                    switch (minion.GetJungleType())
                    {
                        case Extensions.JungleType.Small:
                            SmallJungleMinions.Add(minion);
                            break;
                        case Extensions.JungleType.Large:
                            LargeJungleMinions.Add(minion);
                            break;
                        case Extensions.JungleType.Epic:
                            EpicJungleMinions.Add(minion);
                            break;
                        case Extensions.JungleType.Legendary:
                            LegendaryJungleMinions.Add(minion);
                            break;
                    }

                    AllJungleMinions.Add(minion);
                }

                return;
            }

            var particle = sender as Obj_GeneralParticleEmitter;
            if (particle != null)
            {
                AllParticleEmitters.Add(particle);
                return;
            }

            var turret = sender as Obj_AI_Turret;
            if (turret != null)
            {
                AllTurrets.Add(turret);

                if (turret.IsEnemy)
                {
                    EnemyTurrets.Add(turret);
                }
                else
                {
                    AllyTurrets.Add(turret);
                }

                return;
            }

            var shop = sender as Obj_Shop;
            if (shop != null)
            {
                AllShops.Add(shop);

                if (shop.IsAlly)
                {
                    AllyShops.Add(shop);
                }
                else
                {
                    EnemyShops.Add(shop);
                }

                return;
            }

            var spawnPoint = sender as Obj_SpawnPoint;
            if (spawnPoint != null)
            {
                AllSpawnPoints.Add(spawnPoint);

                if (spawnPoint.IsAlly)
                {
                    AllySpawnPoints.Add(spawnPoint);
                }
                else
                {
                    EnemySpawnPoints.Add(spawnPoint);
                }
            }

            var inhibitor = sender as Obj_BarracksDampener;
            if (inhibitor != null)
            {
                AllInhibitors.Add(inhibitor);

                if (inhibitor.IsAlly)
                {
                    AllyInhibitors.Add(inhibitor);
                }
                else
                {
                    EnemyInhibitors.Add(inhibitor);
                }
            }

            var nexus = sender as Obj_HQ;
            if (nexus != null)
            {
                AllNexus.Add(nexus);

                if (nexus.IsAlly)
                {
                    AllyNexus = nexus;
                }
                else
                {
                    EnemyNexus = nexus;
                }
            }

            var missile = sender as MissileClient;
            if (missile != null)
            {
                AllMissiles.Add(missile);

                if (missile.IsAlly)
                {
                    AllyMissiles.Add(missile);
                }
                else
                {
                    EnemyMissiles.Add(missile);
                }
            }
        }

        private void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            AllObjects.Remove(sender);

            var hero = sender as AIHeroClient;
            if (hero != null)
            {
                AllHeroes.Remove(hero);
                if (hero.IsEnemy)
                {
                    EnemyHeroes.Remove(hero);
                    AllEnemies.Remove(hero);
                }
                else
                {
                    AllyHeroes.Remove(hero);
                    AllAllies.Remove(hero);
                }

                return;
            }

            var minion = sender as Obj_AI_Minion;
            if (minion != null)
            {
                if (minion.Team != GameObjectTeam.Neutral)
                {
                    if (minion.GetMinionType().HasFlag(Extensions.MinionTypes.Ward))
                    {
                        AllWards.Remove(minion);
                        if (minion.IsEnemy)
                        {
                            EnemyWards.Remove(minion);
                        }
                        else
                        {
                            AllyWards.Remove(minion);
                        }
                    }
                    else
                    {
                        AllMinions.Remove(minion);
                        if (minion.IsEnemy)
                        {
                            EnemyMinions.Remove(minion);
                            AllEnemies.Remove(minion);
                        }
                        else
                        {
                            AllyMinions.Remove(minion);
                            AllAllies.Remove(minion);
                        }
                    }
                }
                else if (minion.Name != "WardCorpse")
                {
                    switch (minion.GetJungleType())
                    {
                        case Extensions.JungleType.Small:
                            SmallJungleMinions.Remove(minion);
                            break;
                        case Extensions.JungleType.Large:
                            LargeJungleMinions.Remove(minion);
                            break;
                        case Extensions.JungleType.Epic:
                            EpicJungleMinions.Remove(minion);
                            break;
                        case Extensions.JungleType.Legendary:
                            LegendaryJungleMinions.Remove(minion);
                            break;
                    }

                    AllJungleMinions.Remove(minion);
                }

                return;
            }

            var particle = sender as Obj_GeneralParticleEmitter;
            if (particle != null)
            {
                AllParticleEmitters.Remove(particle);
                return;
            }

            var turret = sender as Obj_AI_Turret;
            if (turret != null)
            {
                AllTurrets.Remove(turret);

                if (turret.IsEnemy)
                {
                    EnemyTurrets.Remove(turret);
                }
                else
                {
                    AllyTurrets.Remove(turret);
                }

                return;
            }

            var shop = sender as Obj_Shop;
            if (shop != null)
            {
                AllShops.Remove(shop);

                if (shop.IsAlly)
                {
                    AllyShops.Remove(shop);
                }
                else
                {
                    EnemyShops.Remove(shop);
                }

                return;
            }

            var spawnPoint = sender as Obj_SpawnPoint;
            if (spawnPoint != null)
            {
                AllSpawnPoints.Remove(spawnPoint);

                if (spawnPoint.IsAlly)
                {
                    AllySpawnPoints.Remove(spawnPoint);
                }
                else
                {
                    EnemySpawnPoints.Remove(spawnPoint);
                }
            }

            var inhibitor = sender as Obj_BarracksDampener;
            if (inhibitor != null)
            {
                AllInhibitors.Remove(inhibitor);

                if (inhibitor.IsAlly)
                {
                    AllyInhibitors.Remove(inhibitor);
                }
                else
                {
                    EnemyInhibitors.Remove(inhibitor);
                }
            }

            var nexus = sender as Obj_HQ;
            if (nexus != null)
            {
                AllNexus.Remove(nexus);

                if (nexus.IsAlly)
                {
                    AllyNexus = null;
                }
                else
                {
                    EnemyNexus = null;
                }
            }

            var missile = sender as MissileClient;
            if (missile != null)
            {
                AllMissiles.Remove(missile);

                if (missile.IsAlly)
                {
                    AllyMissiles.Remove(missile);
                }
                else
                {
                    EnemyMissiles.Remove(missile);
                }
            }
        }

        #region Functions

        public IEnumerable<T> Get<T>() where T : GameObject, new()
        {
            return AllObjects.OfType<T>();
        }

        #endregion Functions
    }
}