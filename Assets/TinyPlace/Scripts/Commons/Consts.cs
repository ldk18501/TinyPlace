using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{
    public class Consts
    {
        #region AnimStateName
        //NormalBattle
        public const string Idle = "Idle";
        public const string Dash = "Dash";
        public const string Die = "Die";
        public const string Jump = "Jump";
        public const string Defend = "Defend";
        public const string Run = "Run";
        public const string Strafe_L = "Strafe Left";
        public const string Strafe_R = "Strafe Right";
        public const string Stunned = "Stunned";
        public const string Hurt = "Take Damage";

        public const string Spell_1 = "Cast Spell";
        public const string Spell_2 = "Cast Spell 02";
        public const string JumpAtk_R_1 = "Jump Right Attack 01";
        public const string PunchAtk_R = "Right Punch Attack";
        public const string PunchAtk_L = "Left Punch Attack";
        public const string MeleeAtk_R_1 = "Melee Right Attack 01";
        public const string MeleeAtk_R_2 = "Melee Right Attack 02";
        public const string MeleeAtk_R_3 = "Melee Right Attack 03";
        public const string MeleeAtk_L_1 = "Melee Left Attack 01";
        public const string MagicAtk_R_1 = "Projectile Right Attack 01";
        public const string SpinAtk = "Spin Attack";

        public const string CrossbowwAim_L = "Crossbow Aim";
        public const string CrossbowwReload_L = "Crossbow Reload";
        public const string CrossbowwShoot_L = "Crossbow Shoot Attack";
        public const string CrossbowwAim_R = "Crossbow Right Aim";
        public const string CrossbowwReload_R = "Cross Right Reload";
        public const string CrossbowwShoot_R = "Crossbow Right Shoot Attack";

        //Casual
        public const string Chop = "Chop Tree";
        public const string Clap = "Clapping";
        public const string Cry = "Crying";
        public const string Dig = "Digging";
        public const string Drink = "Drink Potion";
        public const string LayDown = "Idle to Lay Ground";
        public const string Laying = "On the Ground Loop";
        public const string LayUp = "Lay Ground to Idle";
        public const string NodHead = "Nod Head";
        public const string PickUp = "Pick Up";
        public const string Relax = "Relax";
        public const string ShakeHead = "Shake Head";
        public const string SitDown = "Sitting";
        public const string Talk = "Talking";
        public const string Walk = "Walk";
        public const string Victory = "Victory";
        public const string WaveHand = "Wave Hand"; 

        //Fly
        public const string Idle_Fly = "Fly Idle";
        public const string Forward_Fly = "Fly Forward";
        public const string MeleeAtk_R_1_Fly = "Fly Melee Right Attack 01";
        public const string MeleeAtk_R_2_Fly = "Fly Melee Right Attack 02";
        public const string MeleeAtk_R_3_Fly = "Fly Melee Right Attack 03";
        public const string MeleeAtk_L_1_Fly = "Fly Melee Left Attack 01";
        public const string PunchAtk_R_Fly = "Fly Right Punch Attack";
        public const string PunchAtk_L_Fly = "Fly Left Punch Attack";
        public const string CrossbowwShoot_L_Fly = "Fly Crossbow Shoot Attack";
        public const string MagicAtk_R_1_Fly = "Fly Projectile Right Attack 01";
        public const string Spell_1_Fly = "Fly Cast Spell 01";
        public const string Spell_2_Fly = "Fly Cast Spell 02";
        public const string Defend_Fly = "Fly Defend";
        public const string Hurt_Fly = "Fly Take Damage";
        public const string Die_Fly = "Fly Die";

        //Spear
        public const string Idle_Spear = "Spear Idle";
        public const string Walk_Spear = "Spear Walk";
        public const string Run_Spear = "Spear Run";
        public const string Dash_Spear = "Spear Dash";
        public const string Jump_Spear = "Spear Jump";
        public const string MeleeAtk_1_Spear = "Spear Melee Attack 01";
        public const string MeleeAtk_2_Spear = "Spear Melee Attack 02";
        public const string Spell_Spear = "Spear Cast Spell";
        public const string Relax_Spear = "Spear Relax";
        public const string Defend_Spear = "Spear Defend";
        public const string Hurt_Spear = "Spear Take Damage";
        public const string Die_Spear = "Spear Die";

        //THSword
        public const string Idle_THSword = "TH Sword Idle";
        public const string Die_THSword = "TH Sword Die";
        public const string Defend_THSword = "TH Sword Defend";
        public const string Dash_THSword = "TH Sword Dash Without Root Motion";
        public const string Spell_THSword = "TH Sword Cast Spell";
        public const string Jump_THSword = "TH Sword Jump With Root Motion";
        public const string MeleeAtk_1_THSword = "TH Sword Melee Attack 01";
        public const string MeleeAtk_2_THSword = "TH Sword Melee Attack 02";
        public const string Relax_THSword = "TH Sword Melee Attack 02";
        public const string Run_THSword = "TH Sword Run Without Root Motion";
        public const string Hurt_THSword = "TH Sword Take Damage";
        public const string Walk_THSword = "TH Sword Walk Without Root Motion";

        #endregion

        #region AssetsPath
        public const string Prefab_HeroBase = "LittleHeroes/Prefabs/Models/Base Normal";
        public const string Material_Heroes = "LittleHeroes/Materials/";
        public const string Confs = "Configs/";
        #endregion
    }

}