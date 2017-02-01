using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace BlackYasuo
{
    public class DynamicSpell
    {
        #region Fields

        public bool IsChanneling = false;

        private readonly string[] _deleteObject =
        {
            "Fiddlesticks_Base_Drain.troy", "katarina_deathLotus_tar.troy",
            "Galio_Base_R_explo.troy", "Malzahar_Base_R_Beam.troy",
            "ReapTheWhirlwind_green_cas.troy",
        };

        private readonly string[] _processName =
        {
            "DrainChannel", "KatarinaR", "Crowstorm", "GalioIdolOfDurand",
            "AlZaharNetherGrasp", "ReapTheWhirlwind"
        };

        private int _cancelSpellIssue;

        private int _chargedCastedT;

        private int _chargedReqSentT;

        private Vector3 _from;

        private float _range;

        private Vector3 _rangeCheckFrom;

        private float _width;

        #endregion

        #region Constructors and Destructors

        public DynamicSpell()
        {
        }
        public DynamicSpell(
            SpellSlot slot,
            float range = float.MaxValue,
            DamageType damageType = DamageType.Mixed)
        {
            Slot = slot;
            Range = range;
            DamageType = damageType;

            // Default values
            MinHitChancePercent = 75;
        }

        public DynamicSpell(SpellSlot slot)
        {
            Slot = slot;
        }

        #endregion

        #region Enums

        public enum CastStates
        {
            SuccessfullyCasted,
            NotReady,
            NotCasted,
            OutOfRange,
            Collision,
            NotEnoughTargets,
            LowHitChance,
        }

        #endregion

        #region Public Properties

        public bool AddEnemyHitboxToRange { get; set; }
        public bool AddSelfHitboxToRange { get; set; }
        public bool CanBeCanceledByUser { get; set; }
        public string ChargedBuffName { get; set; }
        public int ChargedMaxRange { get; set; }
        public int ChargedMinRange { get; set; }
        public string ChargedSpellName { get; set; }
        public int ChargeDuration { get; set; }

        public bool Collision { get; set; }

        public float Cooldown
        {
            get
            {
                var coolDown = ObjectManager.Player.Spellbook.GetSpell(Slot).CooldownExpires;
                return Game.Time < coolDown ? coolDown - Game.Time : 0;
            }
        }
        public DamageType DamageType { get; set; }
        public float Delay { get; set; }

        public Vector3 From
        {
            get { return !_from.To2D().IsValid() ? ObjectManager.Player.ServerPosition : _from; }
            set { _from = value; }
        }

        public SpellDataInst Instance => Player.Instance.Spellbook.GetSpell(Slot);

        public bool IsChannelTypeSpell { get; set; }
        public bool IsChargedSpell { get; set; }

        public bool IsCharging
        {
            get
            {
                if (!IsReady()) return false;

                return ObjectManager.Player.HasBuff(ChargedBuffName)
                       || Utils.TickCount - _chargedCastedT < 300 + Game.Ping;
            }
        }


        public bool IsSkillshot { get; set; }


        public int LastCastAttemptT { get; set; }
        public bool LetSpellcancel { get; set; }


        public int Level => Player.Instance.Spellbook.GetSpell(Slot).Level;

        public float ManaCost => Player.Instance.Spellbook.GetSpell(Slot).SData.ManaCostArray[Level - 1];

        public int MinHitChancePercent { get; set; }

        public float Range
        {
            get
            {
                var baseRange = _range;

                if (AddSelfHitboxToRange)
                {
                    baseRange += ObjectManager.Player.BoundingRadius;
                }

                if (!IsChargedSpell)
                {
                    return baseRange;
                }

                if (IsCharging)
                {
                    return ChargedMinRange
                           + Math.Min(
                               ChargedMaxRange - ChargedMinRange,
                               (Utils.TickCount - _chargedCastedT) * (ChargedMaxRange - ChargedMinRange)
                               / ChargeDuration - 150);
                }

                return ChargedMaxRange;
            }

            set { _range = value; }
        }

        public Vector3 RangeCheckFrom
        {
            get
            {
                return !_rangeCheckFrom.To2D().IsValid()
                    ? ObjectManager.Player.ServerPosition
                    : _rangeCheckFrom;
            }
            set { _rangeCheckFrom = value; }
        }

        public float RangeSqr => Range * Range;

        public SpellSlot Slot { get; set; }
        public float Speed { get; set; }
        public bool TargetSpellCancel { get; set; }
        public SkillShotType Type { get; set; }

        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
                WidthSqr = value * value;
            }
        }

        public float WidthSqr { get; private set; }

        public bool IsReady()
        {
            return Instance.IsReady;
        }

        #endregion

        #region Public Methods and Operators

        public bool CanCast(Obj_AI_Base unit)
        {
            return IsReady() && unit.IsValidTarget(Range);
        }

        public CastStates Cast(Obj_AI_Base unit, bool packetCast = false, bool aoe = false)
        {
            return _cast(unit, packetCast, aoe);
        }

        public bool Cast(bool packetCast = false)
        {
            return CastOnUnit(ObjectManager.Player, packetCast);
        }

        public bool Cast(Vector2 fromPosition, Vector2 toPosition)
        {
            return Cast(fromPosition.To3D(), toPosition.To3D());
        }

        public bool Cast(Vector3 fromPosition, Vector3 toPosition)
        {
            if (Shop.IsOpen || MenuGUI.IsChatOpen)
            {
                return false;
            }
            return IsReady() && ObjectManager.Player.Spellbook.CastSpell(Slot, fromPosition, toPosition);
        }

        public bool Cast(Vector2 position, bool packetCast = false)
        {
            if (Shop.IsOpen || MenuGUI.IsChatOpen)
            {
                return false;
            }
            return Cast(position.To3D(), packetCast);
        }

        public bool Cast(Vector3 position, bool packetCast = false)
        {
            if (!IsReady())
            {
                return false;
            }

            LastCastAttemptT = Utils.TickCount;

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

            else if (IsChannelTypeSpell)
            {
                if (TargetSpellCancel)
                {
                    CastCancelSpell(position);
                }
                else
                {
                    CastCancelSpell();
                }
            }

            else if (packetCast)
            {
                return ObjectManager.Player.Spellbook.CastSpell(Slot, position, false);
            }
            else
            {
                return ObjectManager.Player.Spellbook.CastSpell(Slot, position);
            }
            return false;
        }

        public void CastCancelSpell()
        {
            if (!IsChanneling && Utils.TickCount - _cancelSpellIssue > 400 + Game.Ping)
            {
                ObjectManager.Player.Spellbook.CastSpell(Slot);
                _cancelSpellIssue = Utils.TickCount;
            }
        }

        public void CastCancelSpell(Vector3 position)
        {
            if (!IsChanneling && Utils.TickCount - _cancelSpellIssue > 400 + Game.Ping)
            {
                ObjectManager.Player.Spellbook.CastSpell(Slot, position);
                _cancelSpellIssue = Utils.TickCount;
            }
        }

        public bool CastIfHitchanceEquals(Obj_AI_Base unit, int hitChance, bool packetCast = false)
        {
            var currentHitchance = MinHitChancePercent;
            MinHitChancePercent = hitChance;
            var castResult = _cast(unit, packetCast, false, false);
            MinHitChancePercent = currentHitchance;
            return castResult == CastStates.SuccessfullyCasted;
        }

        public bool CastIfWillHit(Obj_AI_Base unit, int minTargets = 5, bool packetCast = false)
        {
            var castResult = _cast(unit, packetCast, true, false, minTargets);
            return castResult == CastStates.SuccessfullyCasted;
        }

        public CastStates CastOnBestTarget(float extraRange = 0, bool packetCast = false, bool aoe = false)
        {
            if (Shop.IsOpen || MenuGUI.IsChatOpen)
            {
                return CastStates.NotCasted;
            }

            var target = GetTarget(extraRange);
            return target != null ? Cast(target, packetCast, aoe) : CastStates.NotCasted;
        }

        public bool CastOnUnit(Obj_AI_Base unit, bool packetCast = false)
        {
            if (!IsReady() || From.Distance(unit.ServerPosition, true) > GetRangeSqr(unit))
            {
                return false;
            }

            if (Shop.IsOpen || MenuGUI.IsChatOpen)
            {
                return false;
            }

            LastCastAttemptT = Utils.TickCount;

            if (packetCast)
            {
                return ObjectManager.Player.Spellbook.CastSpell(Slot, unit, false);
            }
            else
            {
                return ObjectManager.Player.Spellbook.CastSpell(Slot, unit);
            }
        }
        /*
        public int CountHits(List<Obj_AI_Base> units, Vector3 castPosition)
        {
            var points = units.Select(unit => GetPrediction(unit).UnitPosition).ToList();
            return CountHits(points, castPosition);
        }

        public int CountHits(List<Vector3> points, Vector3 castPosition)
        {
            return points.Count(point => WillHit(point, castPosition));
        }

        public List<Obj_AI_Base> GetCollision(Vector2 from, List<Vector2> to, float delayOverride = -1)
        {
            return Common.Collision.GetCollision(
                to.Select(h => h.To3D()).ToList(),
                new Prediction.Manager.PredictionInput
                {
                    From = from.To3D(),
                    Type = Type,
                    Radius = Width,
                    Delay = delayOverride > 0 ? delayOverride : Delay,
                    Speed = Speed
                });
        }
        
        public Prediction.Manager.PredictionOutput GetPrediction(
            AIHeroClient unit,
            bool aoe = false,
            float overrideRange = -1,
            CollisionableObjects[] collisionable = null)
        {
            return
                Prediction.GetPrediction(
                    new Prediction.Manager.PredictionInput
                    {
                        Unit = unit,
                        Delay = Delay,
                        Radius = Width,
                        Speed = Speed,
                        From = From,
                        Range = (overrideRange > 0) ? overrideRange : Range,
                        Collision = Collision,
                        Type = Type,
                        RangeCheckFrom = RangeCheckFrom,
                        Aoe = aoe,
                        CollisionObjects =
                            collisionable ?? new[] { CollisionableObjects.Heroes, CollisionableObjects.Minions }
                    });
        }*/

        public float GetRange(Obj_AI_Base target)
        {
            var result = Range;

            if (AddEnemyHitboxToRange && target != null)
            {
                result += target.BoundingRadius;
            }

            return result;
        }

        public float GetRangeSqr(Obj_AI_Base target)
        {
            var result = GetRange(target);
            return result * result;
        }
        
        public AIHeroClient GetTarget(float extraRange = 0, IEnumerable<AIHeroClient> champsToIgnore = null)
        {
            return TargetSelector.GetTarget(Range + extraRange, DamageType);
        }
        
        public bool IsInRange(GameObject obj, float range = -1)
        {
            return IsInRange(
                (obj as Obj_AI_Base)?.ServerPosition.To2D() ?? obj.Position.To2D(),
                range);
        }

        public bool IsInRange(Vector3 point, float range = -1)
        {
            return IsInRange(point.To2D(), range);
        }

        public bool IsInRange(Vector2 point, float range = -1)
        {
            return RangeCheckFrom.To2D().Distance(point, true) < (range < 0 ? RangeSqr : range * range);
        }

        public void SetCharged(string spellName, string buffName, int minRange, int maxRange, float deltaT)
        {
            IsChargedSpell = true;
            ChargedSpellName = spellName;
            ChargedBuffName = buffName;
            ChargedMinRange = minRange;
            ChargedMaxRange = maxRange;
            ChargeDuration = (int)(deltaT * 1000);
            _chargedCastedT = 0;

            Obj_AI_Base.OnProcessSpellCast += AIHeroClient_OnProcessSpellCast;
            Spellbook.OnUpdateChargeableSpell += Spellbook_OnUpdateChargedSpell;
            Spellbook.OnCastSpell += SpellbookOnCastSpell;
        }

        public void Setinterruptible(bool letUserCancel, bool targetted, bool letSpellCancel = false)
        {
            CanBeCanceledByUser = letUserCancel;
            TargetSpellCancel = targetted;
            IsChanneling = false;
            LetSpellcancel = letSpellCancel;

            Obj_AI_Base.OnSpellCast += OnDoCast;
            GameObject.OnDelete += OnDelete;
            Game.OnWndProc += OnWndProc;
            Player.OnIssueOrder += OnOrder;
            Spellbook.OnCastSpell += OnCastSpell;

            if (ObjectManager.Player.ChampionName == "Fiddlesticks")
            {
                GameObject.OnCreate += OnCreate;
            }
        }

        public void SetSkillshot(
            float delay,
            float width,
            float speed,
            bool collision,
            SkillShotType type,
            Vector3 from = new Vector3(),
            Vector3 rangeCheckFrom = new Vector3())
        {
            Delay = delay;
            Width = width;
            Speed = speed;
            From = from;
            Collision = collision;
            Type = type;
            RangeCheckFrom = rangeCheckFrom;
            IsSkillshot = true;
        }

        public void SetTargetted(
            float delay,
            float speed,
            Vector3 from = new Vector3(),
            Vector3 rangeCheckFrom = new Vector3())
        {
            Delay = delay;
            Speed = speed;
            From = from;
            RangeCheckFrom = rangeCheckFrom;
            IsSkillshot = false;
        }

        public void StartCharging()
        {
            if (!IsCharging && Utils.TickCount - _chargedReqSentT > 400 + Game.Ping)
            {
                ObjectManager.Player.Spellbook.CastSpell(Slot);
                _chargedReqSentT = Utils.TickCount;
            }
        }

        public void StartCharging(Vector3 position)
        {
            if (!IsCharging && Utils.TickCount - _chargedReqSentT > 400 + Game.Ping)
            {
                ObjectManager.Player.Spellbook.CastSpell(Slot, position);
                _chargedReqSentT = Utils.TickCount;
            }
        }

        public void UpdateSourcePosition(Vector3 from = new Vector3(), Vector3 rangeCheckFrom = new Vector3())
        {
            From = from;
            RangeCheckFrom = rangeCheckFrom;
        }

        public bool WillHit(
            Obj_AI_Base unit,
            Vector3 castPosition,
            int extraWidth = 0,
            HitChance minHitChance = HitChance.High)
        {
            /*
            var unitPosition = GetPrediction(unit);
            return unitPosition.Hitchance >= minHitChance
                   && WillHit(unitPosition.UnitPosition, castPosition, extraWidth);*/
            return false;
        }

        public bool WillHit(Vector3 point, Vector3 castPosition, int extraWidth = 0)
        {
            switch (Type)
            {
                case SkillShotType.Circular:
                    if (point.To2D().Distance(castPosition, true) < WidthSqr)
                    {
                        return true;
                    }
                    break;

                case SkillShotType.Linear:
                    if (point.To2D().Distance(castPosition.To2D(), From.To2D(), true, true)
                        < Math.Pow(Width + extraWidth, 2))
                    {
                        return true;
                    }
                    break;
                case SkillShotType.Cone:
                    var edge1 = (castPosition.To2D() - From.To2D()).Rotated(-Width / 2);
                    var edge2 = edge1.Rotated(Width);
                    var v = point.To2D() - From.To2D();
                    if (point.To2D().Distance(From, true) < RangeSqr && edge1.CrossProduct(v) > 0
                        && v.CrossProduct(edge2) > 0)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="position"></param>
        /// <param name="releaseCast"></param>
        private static void ShootChargedSpell(SpellSlot slot, Vector3 position, bool releaseCast = true)
        {
            position.Z = NavMesh.GetHeightForPosition(position.X, position.Y);
            ObjectManager.Player.Spellbook.UpdateChargeableSpell(slot, position, releaseCast, false);
            ObjectManager.Player.Spellbook.CastSpell(slot, position, false);
        }

        private CastStates _cast(
            Obj_AI_Base unit,
            bool packetCast = false,
            bool aoe = false,
            bool exactHitChance = false,
            int minTargets = -1)
        {
            if (unit == null || Shop.IsOpen || MenuGUI.IsChatOpen)
            {
                return CastStates.NotCasted;
            }

            //Spell not ready.
            if (!IsReady())
            {
                return CastStates.NotReady;
            }

            if (minTargets != -1)
            {
                aoe = true;
            }

            //Targetted spell.
            if (!IsSkillshot)
            {
                //Target out of range
                if (RangeCheckFrom.Distance(unit.ServerPosition, true) > GetRangeSqr(unit))
                {
                    return CastStates.OutOfRange;
                }

                LastCastAttemptT = Utils.TickCount;

                if (packetCast)
                {
                    if (!ObjectManager.Player.Spellbook.CastSpell(Slot, unit, false))
                    {
                        return CastStates.NotCasted;
                    }
                }
                else
                {
                    //Cant cast the Spell.
                    if (!ObjectManager.Player.Spellbook.CastSpell(Slot, unit))
                    {
                        return CastStates.NotCasted;
                    }
                }

                return CastStates.SuccessfullyCasted;
            }
            /*
            //Get the best position to cast the spell.
            var prediction = GetPrediction(unit, aoe);

            if (minTargets != -1 && prediction.AoeTargetsHitCount < minTargets)
            {
                return CastStates.NotEnoughTargets;
            }

            //Skillshot collides.
            if (prediction.CollisionObjects.Count > 0)
            {
                return CastStates.Collision;
            }

            //Target out of range.
            if (Vector3.Distance(prediction.CastPosition, true) > RangeSqr)
            {
                return CastStates.OutOfRange;
            }

            //The hitchance is too low.
            if (prediction.Hitchance < MinHitChance
                || (exactHitChance && prediction.Hitchance != MinHitChance))
            {
                return CastStates.LowHitChance;
            }

            LastCastAttemptT = Utils.TickCount;

            if (IsChargedSpell)
            {
                if (IsCharging)
                {
                    ShootChargedSpell(Slot, prediction.CastPosition);
                }
                else
                {
                    StartCharging();
                }
            }
            else if (packetCast)
            {
                ObjectManager.Player.Spellbook.CastSpell(Slot, prediction.CastPosition, false);
            }
            else
            {
                //Cant cast the spell (actually should not happen).
                if (!ObjectManager.Player.Spellbook.CastSpell(Slot, prediction.CastPosition))
                {
                    return CastStates.NotCasted;
                }
            }
            */
            return CastStates.SuccessfullyCasted;
            
        }

        private void AIHeroClient_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe && args.SData.Name == ChargedSpellName)
            {
                _chargedCastedT = Utils.TickCount;
            }
        }

        private void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (LetSpellcancel) return;

            args.Process = !IsChanneling;
        }

        private void OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.Name == "Fiddlesticks_Base_Base_Crowstorm_green_cas.troy")
            {
                IsChanneling = false;
            }
        }

        private void OnDelete(GameObject sender, EventArgs args)
        {
            if (_deleteObject.Contains(sender.Name))
            {
                IsChanneling = false;
            }
        }

        private void OnDoCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;

            if (_processName.Contains(args.SData.Name))
            {
                IsChanneling = true;
            }
        }

        private void OnOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (!sender.IsMe) return;

            if (!IsChanneling) return;

            if (args.Order == GameObjectOrder.MoveTo || args.Order == GameObjectOrder.AttackTo
                || args.Order == GameObjectOrder.AttackUnit || args.Order == GameObjectOrder.AutoAttack)
            {
                args.Process = false;
            }
        }

        private void OnWndProc(WndEventArgs args)
        {
            if (!CanBeCanceledByUser) return;

            if (args.Msg == 517)
            {
                IsChanneling = false;
            }
        }

        void Spellbook_OnUpdateChargedSpell(Spellbook sender, SpellbookUpdateChargeableSpellEventArgs args)
        {
            if (sender.Owner.IsMe && Utils.TickCount - _chargedReqSentT < 3000 && args.ReleaseCast)
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

            if ((Utils.TickCount - _chargedReqSentT > 500))
            {
                if (IsCharging)
                {
                    Cast(args.StartPosition.To2D());
                }
            }
        }

        #endregion
    }
}
