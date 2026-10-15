using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Rendering;

namespace ITHS_LABB_2_dungeon_crawler.Game
{
    public static class Combat
    {
        public static void Fight(IFightable attacker, IFightable defender)
        {
            int attackRoll = attacker.AttackDice.Throw();
            int defenceRoll = defender.DefenceDice.Throw();

            int attackCalcDamage = Math.Max(0, attackRoll - defenceRoll);

            defender.HP -= attackCalcDamage;

            GameRenderer.CombatLog(attacker, defender, true, attackRoll, defenceRoll, attackCalcDamage);

            if (defender.HP <= 0)
            {
                GameRenderer.DeathLog(defender);

                return;
            }

            int counterAttackRoll = defender.AttackDice.Throw();
            int counterDefenceRoll = attacker.DefenceDice.Throw();

            int counterAttackCalcDamage = Math.Max(0, counterAttackRoll - counterDefenceRoll);

            attacker.HP -= counterAttackCalcDamage;

            GameRenderer.CombatLog(defender, attacker, false, counterAttackRoll, counterDefenceRoll, counterAttackCalcDamage);

            if (attacker.HP <= 0)
            {
                GameRenderer.DeathLog(attacker);
                Console.ResetColor();
            }
        }
    }
}
