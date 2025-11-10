using System.Collections.Generic;
using System.Linq;
using Character;
using Enums;
using Equipment;
using Managers;
using UnityEngine;

namespace Passives
{
    public class PassiveHandler : MonoBehaviour
    {
        public List<PassiveBase> listOfCharacterPassives;
        public CharacterBase user;
        public CharacterBase opponent;

        public void AddCharacterPassive(PassiveBase addedPassive)
        {
            listOfCharacterPassives.Add(addedPassive);
            if (!addedPassive.isTriggeredEffect)
            {
                addedPassive.ApplyConstantEffect();
            }
        }

        public void TriggerPassives(int executionInt)
        {
            var executionOrder = executionInt switch
            {
                0 => EExecutionOrder.PlayerBeforeTurn,
                1 => EExecutionOrder.PlayerBeforeAction,
                2 => EExecutionOrder.PlayerAfterAction,
                3 => EExecutionOrder.EnemyBeforeTurn,
                4 => EExecutionOrder.EnemyBeforeAction,
                5 => EExecutionOrder.EnemyAfterAction,
                6 => EExecutionOrder.OnEquip,
                _ => EExecutionOrder.PlayerBeforeTurn
            };

            foreach (var passive in listOfCharacterPassives.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
            {
                passive.TriggerEffect(user, opponent);
            }

            CharacterInventory inv = null;

            if (GetComponent<CharacterBase>().characterInventory != null)
            {
                inv = GetComponent<CharacterBase>().characterInventory;
            }

            if (inv != null)
            {
                if (inv.headSlot != null)
                {
                    foreach (var passive in inv.headSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect(user, opponent);
                    }
                }

                if (inv.chestSlot != null)
                {
                    foreach (var passive in inv.chestSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect(user, opponent);
                    }
                }

                if (inv.legSlot != null)
                {
                    foreach (var passive in inv.legSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect(user, opponent);
                    }
                }

                if (inv.armSlot != null)
                {
                    foreach (var passive in inv.armSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect(user, opponent);
                    }
                }
            }
        }
    }
}