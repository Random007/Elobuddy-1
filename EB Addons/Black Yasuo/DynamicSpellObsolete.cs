using System;
using System.Collections.Generic;
using System.Linq;
using BlackYasuo.Databases;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using SharpDX;

namespace BlackYasuo
{
    public class DynamicSpellObsolete
    {
        #region Private Fields

        private int chargedCastedT;
        private int chargedReqSentT;
        private Vector3 from;
        private int range;
        private Vector3 rangeCheckFrom;
        private int width;

        #endregion Private Fields

        public DynamicSpellObsolete(SpellSlot slot, int range)
        {
            Slot = slot;
            Range = range;
        }

        #region Delegates

        public delegate bool CastConditionDelegate();

        #endregion

        #region Public Properties

        public CastConditionDelegate CastCondition { get; set; }

        public SpellDataInst Handle => Player.GetSpell(Slot);

        public bool HasCollision { get; set; }
        public int AllowedCollisionCount { get; set; }
        public string ChargedBuffName { get; set; }
        public int ChargedMaxRange { get; set; }
        public int ChargedMinRange { get; set; }
        public string ChargedSpellName { get; set; }
        public int ChargeDuration { get; set; }
        public int Delay { get; set; }

        private DamageType DamageType => DamageDB.GetDamageType(Player.Instance.Hero);

        public Vector3 From
        {
            get { return !from.IsZero ? Player.Instance.ServerPosition : from; }

            set { from = value; }
        }

        public SpellDataInst Instance => Player.Instance.Spellbook.GetSpell(Slot);
        public bool IsChargedSpell { get; set; }

        public bool IsCharging
        {
            get
            {
                if (!IsReady())
                {
                    return false;
                }

                return Player.Instance.HasBuff(ChargedBuffName)
                       || Core.GameTickCount - chargedCastedT < 300 + Game.Ping;
            }
        }

        public bool IsSkillshot { get; set; }
        public int LastCastAttemptT { get; set; }
        public int Level => Player.Instance.Spellbook.GetSpell(Slot).Level;

        public int Range
        {
            get
            {
                if (!IsChargedSpell)
                {
                    return range;
                }

                if (IsCharging)
                {
                    return ChargedMinRange
                           + Math.Min(
                               ChargedMaxRange - ChargedMinRange,
                               ((Core.GameTickCount - chargedCastedT)
                                * (ChargedMaxRange - ChargedMinRange) / ChargeDuration) - 150);
                }

                return ChargedMaxRange;
            }

            set { range = value; }
        }

        public Vector3 RangeCheckFrom
        {
            get { return !rangeCheckFrom.IsZero ? Player.Instance.ServerPosition : rangeCheckFrom; }

            set { rangeCheckFrom = value; }
        }

        public float RangeSqr => Range * Range;

        public SpellSlot Slot { get; set; }

        public int Speed { get; set; }

        public SkillShotType SkillShotTypeType { get; set; }

        public int Width
        {
            get { return width; }

            set
            {
                width = value;
                WidthSqr = value * value;
            }
        }

        public int WidthSqr { get; private set; }

        #endregion

        #region CastFunctions

        public virtual bool CastMinimumHitchance(Obj_AI_Base targetEntity, int hitChance)
        {
            if (targetEntity == null) return false;
            var pred = GetPrediction(targetEntity);
            if (pred != null)
            {
                return pred.HitChancePercent >= hitChance && Cast(pred.CastPosition);
            }
            return false;
        }

        public virtual bool CastIfItWillHit(int minTargets = 2, int minHitchancePercent = 75)
        {
            switch (SkillShotTypeType)
            {
                case SkillShotType.Linear:
                    var targetsLinear = EntityManager.Heroes.Enemies.Where(CanCast).ToArray();
                    var pred = GetBestLinearCastPosition(targetsLinear);

                    if (pred.CastPosition != Vector3.Zero && pred.HitNumber > 0)
                    {
                        if (pred.HitNumber >= minTargets)
                        {
                            return Cast(pred.CastPosition);
                        }
                    }
                    break;
                case SkillShotType.Circular:
                    var targetsCircular = EntityManager.Heroes.Enemies.Where(CanCast).ToArray();
                    var predCircular = GetBestLinearCastPosition(targetsCircular);

                    if (predCircular.CastPosition != Vector3.Zero && predCircular.HitNumber > 0)
                    {
                        if (predCircular.HitNumber >= minTargets)
                        {
                            return Cast(predCircular.CastPosition);
                        }
                    }
                    break;
                case SkillShotType.Cone:
                    var targetsCone = EntityManager.Heroes.Enemies.Where(CanCast).ToArray();
                    var predCone = GetBestLinearCastPosition(targetsCone);

                    if (predCone.CastPosition != Vector3.Zero && predCone.HitNumber > 0)
                    {
                        if (predCone.HitNumber >= minTargets)
                        {
                            return Cast(predCone.CastPosition);
                        }
                    }
                    break;
            }
            return false;
        }

        #region BestPosition Getters
        public struct BestPosition
        {
            public int HitNumber;
            public Vector3 CastPosition;
        }

        public virtual BestPosition GetBestLinearCastPosition(IEnumerable<Obj_AI_Base> entities, int moreDelay = 0, Vector2? sourcePosition = null)
        {
            var targets = entities.ToArray();

            switch (targets.Length)
            {
                case 0:
                    return new BestPosition();
                case 1:
                    return new BestPosition { CastPosition = targets[0].ServerPosition, HitNumber = 1 };
            }

            var possiblePositions = new List<Vector2>(targets.OrderBy(o => o.Health).Select(o => Prediction.Position.PredictUnitPosition(o, Delay + moreDelay)));
            foreach (var target in targets)
            {
                var predictedPos = Prediction.Position.PredictUnitPosition(target, Delay + moreDelay);
                possiblePositions.AddRange(from t in targets orderby t.Health where t.NetworkId != target.NetworkId select (predictedPos + predictedPos) / 2);
            }

            var startPos = sourcePosition ?? Player.Instance.ServerPosition.To2D();
            var minionCount = 0;
            var result = Vector2.Zero;

            foreach (var pos in possiblePositions.Where(o => o.IsInRange(startPos, Range)))
            {
                var endPos = startPos + Range * (pos - startPos).Normalized();
                var count = targets.Where(t => t.IsValidTarget()).OrderBy(o => o.Health).Count(o => Prediction.Position.PredictUnitPosition(o, Delay + moreDelay).Distance(startPos, endPos, true, true) <= Width * Width);

                if (count >= minionCount)
                {
                    result = endPos;
                    minionCount = count;
                }
            }

            return new BestPosition { CastPosition = result.To3DWorld(), HitNumber = minionCount };
        }

        public virtual BestPosition GetBestCircularCastPosition(IEnumerable<Obj_AI_Base> entities, int moreDelay = 0,
            int hitChance = 60)
        {
            var bestCircularCastPos =
                Prediction.Position.PredictCircularMissileAoe(entities.ToArray(), Range, Width, Delay,
                    Speed)
                    .OrderByDescending(r => r.GetCollisionObjects<AIHeroClient>().Length)
                    .ThenByDescending(r => r.GetCollisionObjects<Obj_AI_Base>().Length)
                    .FirstOrDefault();

            if (bestCircularCastPos != null && bestCircularCastPos.HitChancePercent >= hitChance)
            {
                var predictedTargets = bestCircularCastPos.GetCollisionObjects<AIHeroClient>().Concat(bestCircularCastPos.GetCollisionObjects<Obj_AI_Base>());
                return new BestPosition
                {
                    CastPosition = bestCircularCastPos.CastPosition,
                    HitNumber = predictedTargets.Count()
                };
            }

            return new BestPosition {CastPosition = Vector3.Zero, HitNumber = 0};
        }

        public virtual BestPosition GetBestConeCastPosition(IEnumerable<Obj_AI_Base> entities, int moreDelay = 0,int hitChance = 60)
        {
            var bestCastConePos =
                Prediction.Position.PredictConeSpellAoe(entities.ToArray(), Range, Width, Delay, Speed)
                    .OrderByDescending(r => r.GetCollisionObjects<AIHeroClient>().Length)
                    .FirstOrDefault();

            if (bestCastConePos != null && bestCastConePos.HitChancePercent >= hitChance)
            {
                var predictedTargets = bestCastConePos.GetCollisionObjects<AIHeroClient>().Concat(bestCastConePos.GetCollisionObjects<Obj_AI_Base>());
                return new BestPosition
                {
                    CastPosition = bestCastConePos.CastPosition,
                    HitNumber = predictedTargets.Count()
                };
            }

            return new BestPosition { CastPosition = Vector3.Zero, HitNumber = 0 };
        }

        #endregion BestPosition Getters

        public virtual bool CastOnBestFarmPosition(int minMinion = 3)
        {
            switch (SkillShotTypeType)
            {
                case SkillShotType.Linear:
                    var minionsLinear = EntityManager.MinionsAndMonsters.EnemyMinions.Where(CanCast).OrderBy(m => m.Health);
                    var farmLocationLinear = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minionsLinear,
                        Width, Range);
                    if (farmLocationLinear.HitNumber >= minMinion)
                    {
                        Cast(farmLocationLinear.CastPosition);
                    }
                    break;
                case SkillShotType.Circular:
                    var minionsCircular = EntityManager.MinionsAndMonsters.EnemyMinions.Where(CanCast).OrderBy(m => m.Health).ToArray();
                    var farmLocationCircular =
                        Prediction.Position.PredictCircularMissileAoe(minionsCircular, Range, Width, Delay,
                            Speed)
                            .OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length)
                            .FirstOrDefault();

                    if (farmLocationCircular != null && farmLocationCircular.HitChancePercent >= 75)
                    {
                        var predictedMinion = farmLocationCircular.GetCollisionObjects<Obj_AI_Minion>();
                        if (predictedMinion.Length >= minMinion)
                        {
                            return Cast(farmLocationCircular.CastPosition);
                        }
                    }
                    break;
                case SkillShotType.Cone:
                    var minionsCone = EntityManager.MinionsAndMonsters.EnemyMinions.Where(CanCast).OrderBy(m => m.Health).ToArray();
                    var farmLocationCone =
                        Prediction.Position.PredictConeSpellAoe(minionsCone, Range, Width, Delay, Speed)
                            .OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length)
                            .FirstOrDefault();

                    if (farmLocationCone != null && farmLocationCone.HitChancePercent >= 75)
                    {
                        var predictedMinion = farmLocationCone.GetCollisionObjects<Obj_AI_Minion>();
                        if (predictedMinion.Length >= minMinion)
                        {
                            return Cast(farmLocationCone.CastPosition);
                        }
                    }
                    break;
            }
            return false;
        }

        #endregion  CastFunctions

        #region Public Methods and Operators

        public virtual AIHeroClient GetTarget(int extraRange = 0)
        {
            return TargetSelector.GetTarget(Range + extraRange, DamageType);
        }

        public bool CanCast(Obj_AI_Base target)
        {
            return target != null && IsReady() && target.IsValidTarget(Range);
        }

        public bool CanKill(Obj_AI_Base target, float damage)
        {
            var predH = PredictedHealth(target);
            return CanCast(target) && damage > predH && predH > 50;
        }

        public float PredictedHealth(Obj_AI_Base target)
        {
            return Prediction.Health.GetPrediction(target, Delay);
        }

        public bool Cast()
        {
            return CastOnUnit(Player.Instance);
        }

        public bool Cast(Vector2 fromPosition, Vector2 toPosition)
        {
            return Cast(fromPosition.To3D(), toPosition.To3D());
        }

        public bool Cast(Vector3 fromPosition, Vector3 toPosition)
        {
            if (!IsReady())
            {
                return false;
            }

            if (CastCondition != null && !CastCondition())
            {
                return false;
            }

            LastCastAttemptT = Core.GameTickCount;

            return Player.Instance.Spellbook.CastSpell(Slot, fromPosition, toPosition);
        }

        public bool Cast(Vector2 position)
        {
            return Cast(position.To3D());
        }

        public bool Cast(Vector3 position)
        {
            if (!IsReady())
            {
                return false;
            }

            if (CastCondition != null && !CastCondition())
            {
                return false;
            }

            LastCastAttemptT = Core.GameTickCount;

            if (IsChargedSpell)
            {
                if (IsCharging)
                {
                    ShootChargedSpell(Slot, position);
                }
                else
                {
                    StartCharging();
                }
            }
            else
            {
                return Player.Instance.Spellbook.CastSpell(Slot, position);
            }

            return false;
        }

        public bool CastOnUnit(Obj_AI_Base unit)
        {
            if (unit == null) return false;

            if (!IsReady() || From.DistanceSquared(unit.ServerPosition) > RangeSqr)
            {
                return false;
            }

            if (CastCondition != null && !CastCondition())
            {
                return false;
            }

            LastCastAttemptT = Core.GameTickCount;

            return Player.Instance.Spellbook.CastSpell(Slot, unit);
        }

        public float GetHealthPrediction(Obj_AI_Base unit)
        {
            var time = Delay - 100 + (Game.Ping / 2f);

            if (Math.Abs(Speed - float.MaxValue) > float.Epsilon)
            {
                time += 1000 * Math.Max(unit.Distance(From) - Player.Instance.BoundingRadius, 0) / Speed;
            }

            return Prediction.Health.GetPrediction(unit, (int)time);
        }

        public bool IsInRange(GameObject obj, float otherRange = -1)
        {
            return IsInRange(
                (obj as Obj_AI_Base)?.ServerPosition.To2D() ?? obj.Position.To2D(),
                otherRange);
        }

        public bool IsInRange(Vector3 point, float otherRange = -1)
        {
            return IsInRange(point.To2D(), otherRange);
        }

        public bool IsInRange(Vector2 point, float otherRange = -1)
        {
            return RangeCheckFrom.DistanceSquared(point)
                   < (otherRange < 0 ? RangeSqr : otherRange * otherRange);
        }

        public bool IsReady(int t = 0)
        {
            return Handle.IsReady;
        }
        
        public DynamicSpellObsolete SetCharged(string spellName, string buffName, int minRange, int maxRange, float deltaT)
        {
            IsChargedSpell = true;
            ChargedSpellName = spellName;
            ChargedBuffName = buffName;
            ChargedMinRange = minRange;
            ChargedMaxRange = maxRange;
            ChargeDuration = (int)(deltaT * 1000);
            chargedCastedT = 0;

            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Spellbook.OnUpdateChargeableSpell += Spellbook_OnUpdateChargedSpell;
            Spellbook.OnCastSpell += SpellbookOnCastSpell;

            return this;
        }
        
        public virtual PredictionResult GetPrediction(Obj_AI_Base target)
        {
            if (!IsSkillshot) return null;

            switch (SkillShotTypeType)
            {
                case SkillShotType.Circular:
                    var predDataCircular = new Prediction.Position.PredictionData(Prediction.Position.PredictionData.PredictionType.Circular, Range, Width, 0, Delay, Speed, AllowedCollisionCount, From);
                    return Prediction.Position.GetPrediction(target, predDataCircular);

                case SkillShotType.Linear:
                    var predDataLinear = new Prediction.Position.PredictionData(Prediction.Position.PredictionData.PredictionType.Linear, Range, Width, 0, Delay, Speed, AllowedCollisionCount, From);
                    return Prediction.Position.GetPrediction(target, predDataLinear);

                case SkillShotType.Cone:
                    var predDataCone = new Prediction.Position.PredictionData(Prediction.Position.PredictionData.PredictionType.Linear, Range, 0, Width, Delay, Speed, AllowedCollisionCount, From);
                    return Prediction.Position.GetPrediction(target, predDataCone);

                default:
                    Logger.Log(LogLevel.Warn, "Skillshot type '{0}' not implemented yet!", SkillShotTypeType);
                    break;
            }
            return null;
        }

        public DynamicSpellObsolete SetSkillshot(
            int delay,
            int skillWidth,
            int speed,
            SkillShotType type,
            Vector3 fromVector3 = default(Vector3),
            Vector3 rangeCheckFromVector3 = default(Vector3))
        {
            Delay = delay;
            Width = skillWidth;
            Speed = speed;
            From = fromVector3;
            SkillShotTypeType = type;
            RangeCheckFrom = rangeCheckFromVector3;
            IsSkillshot = true;

            return this;
        }

        public DynamicSpellObsolete SetSkillshot(
            bool collision,
            SkillShotType type,
            Vector3 fromVector3 = default(Vector3),
            Vector3 rangeCheckFromVector3 = default(Vector3))
        {
            From = fromVector3;
            HasCollision = collision;
            SkillShotTypeType = type;
            RangeCheckFrom = rangeCheckFromVector3;
            IsSkillshot = true;

            return this;
        }

        public DynamicSpellObsolete SetTargetted(
            int delay,
            int speed,
            Vector3 fromVector3 = default(Vector3),
            Vector3 rangeCheckFromVector3 = default(Vector3))
        {
            Delay = delay;
            Speed = speed;
            From = fromVector3;
            RangeCheckFrom = rangeCheckFromVector3;
            IsSkillshot = false;

            return this;
        }

        public DynamicSpellObsolete SetTargetted(
            Vector3 fromVector3 = default(Vector3),
            Vector3 rangeCheckFromVector3 = default(Vector3))
        {
            From = fromVector3;
            RangeCheckFrom = rangeCheckFromVector3;
            IsSkillshot = false;

            return this;
        }

        public void StartCharging()
        {
            if (IsCharging || Core.GameTickCount - chargedReqSentT <= 400 + Game.Ping)
            {
                return;
            }

            Player.Instance.Spellbook.CastSpell(Slot);
            chargedReqSentT = Core.GameTickCount;
        }

        public void StartCharging(Vector3 position)
        {
            if (IsCharging || Core.GameTickCount - chargedReqSentT <= 400 + Game.Ping)
            {
                return;
            }

            Player.Instance.Spellbook.CastSpell(Slot, position);
            chargedReqSentT = Core.GameTickCount;
        }

        public void UpdateSourcePosition(Vector3 fromVector3 = default(Vector3), Vector3 rangeCheckFromVector3 = default(Vector3))
        {
            From = fromVector3;
            RangeCheckFrom = rangeCheckFromVector3;
        }

        public void UpdateCollision(bool hasCollision = true)
        {
            HasCollision = hasCollision;

            AllowedCollisionCount = hasCollision ? 0 : int.MaxValue;
        }

        public void UpdateCollision(int collisionCount = 0)
        {
            AllowedCollisionCount = collisionCount;

            HasCollision = collisionCount == 0;
        }


        #endregion

        #region Methods

        private static void ShootChargedSpell(SpellSlot slot, Vector3 position, bool releaseCast = true)
        {
            position.Z = NavMesh.GetHeightForPosition(position.X, position.Y);
            Player.Instance.Spellbook.UpdateChargeableSpell(slot, position, releaseCast, false);
            Player.Instance.Spellbook.CastSpell(slot, position, false);
        }

        private void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe && args.SData.Name == ChargedSpellName)
            {
                chargedCastedT = Core.GameTickCount;
            }
        }

        private void Spellbook_OnUpdateChargedSpell(Spellbook sender, SpellbookUpdateChargeableSpellEventArgs args)
        {
            if (sender.Owner.IsMe && Core.GameTickCount - chargedReqSentT < 3000 && args.ReleaseCast)
            {
                args.Process = false;
            }
        }

        private void SpellbookOnCastSpell(Spellbook spellbook, SpellbookCastSpellEventArgs args)
        {
            if (args.Slot != Slot)
            {
                return;
            }

            if (Core.GameTickCount - chargedReqSentT > 500)
            {
                if (IsCharging)
                {
                    Cast(new Vector2(args.EndPosition.X, args.EndPosition.Y));
                }
            }
        }

        #endregion
    }
}
