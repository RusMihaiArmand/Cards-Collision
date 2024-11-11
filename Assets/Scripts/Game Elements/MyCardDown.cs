using UnityEngine;
using System.Collections;
using System;

namespace SA.GameElements
{

    [CreateAssetMenu(menuName = "Game Elements/My Card Down")]
    public class MyCardDown : GE_Logic
    {
        public override void OnClick(CardInstance inst)
        {


            if (Settings.gameManager.needToSelect == false)
            {

                if (!Settings.gameManager.currentPlayer.IsMyTroop(inst)
                    && !Settings.gameManager.currentPlayer.IsMyBuilding(inst))
                {

                    if (Settings.gameManager.cardToAttack != null)
                    { 

                        if (Settings.gameManager.currentPlayer.playerCard != inst &&
                            Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].playerCard != inst
                            )
                        {
                            PlayerHolder p;

                            if (Settings.gameManager.all_players[0] == Settings.gameManager.currentPlayer) p = Settings.gameManager.all_players[1];
                            else p = Settings.gameManager.all_players[0];



                            int j = 0, k = 0;



                            while (j < Settings.gameManager.cardToAttack.viz.card.properties.Length)
                            {
                                if (Settings.gameManager.cardToAttack.viz.card.properties[j].element.name == "TypeElement")
                                {
                                    if (Settings.gameManager.cardToAttack.viz.card.properties[j].StringValue == "R")
                                        k = 1;
                                }


                                j++;
                            }





                            if (k == 1 || p.IsFrontBuilding(inst) || p.IsFrontTroop(inst) ||
                                (p.IsBackBuilding(inst) && p.HasFrontBuildings() == false && p.HasFrontTroops() == false) ||
                                (p.IsBackTroop(inst) && p.HasFrontTroops() == false))
                                if (Settings.gameManager.cardToAttack != null)
                                {
                                    ///j-cartea atacata; j2-aia CARE ataca; noteaza mai bine data viitoare

                                    int attackedHP = -1, attackedP = -1, attackerHP = -1, attackerP = -1;

                                    for (int i = 0; i < inst.viz.properties.Length; i++)
                                    {
                                        if (inst.viz.properties[i].element.name == "HP")
                                        {
                                            attackedHP = i;
                                        }

                                        if (inst.viz.properties[i].element.name == "Attack")
                                        {
                                            attackedP = i;
                                        }

                                    }



                                    Settings.RegisterEvent(Settings.gameManager.cardToAttack.viz.card.name +
                                        " attacked " + inst.viz.card.name, Settings.gameManager.currentPlayer.playerColor);




                                    for (int i = 0; i < Settings.gameManager.cardToAttack.viz.properties.Length; i++)
                                    {
                                        if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "HP")
                                        {
                                            attackerHP = i;
                                        }

                                        if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "Attack")
                                        {
                                            attackerP = i;
                                        }

                                    }

                                    int damage;

                                    if (attackerP >= 0)
                                    {
                                        damage = Int16.Parse(Settings.gameManager.cardToAttack.viz.properties[attackerP].text.text);

                                        if (inst.viz.card.hasSpecialAttack || Settings.gameManager.cardToAttack.viz.card.hasSpecialAttack)
                                            SpecialInteraction(Settings.gameManager.cardToAttack, inst, ref damage);

                                        inst.viz.properties[attackedHP].text.text =
                                         (Int16.Parse(inst.viz.properties[attackedHP].text.text) -
                                         damage).ToString();


                                    }

                                    if (Settings.gameManager.cardToAttack.viz.card.attackType <= inst.viz.card.counterType)
                                        if (attackedP >= 0)
                                        {
                                            damage = Int16.Parse(inst.viz.properties[attackedP].text.text);


                                            if (inst.viz.card.hasSpecialAttack || Settings.gameManager.cardToAttack.viz.card.hasSpecialAttack)
                                                SpecialInteraction(inst, Settings.gameManager.cardToAttack, ref damage);



                                            Settings.gameManager.cardToAttack.viz.properties[attackerHP].text.text =
                                                 (Int16.Parse(Settings.gameManager.cardToAttack.viz.properties[attackerHP].text.text) -
                                                 damage).ToString();
                                        }

                                    Settings.gameManager.cardToAttack.nrAttacksDone++;

                                    if (Settings.gameManager.cardToAttack.nrAttacksDone >= Settings.gameManager.cardToAttack.viz.card.nrAttacks)
                                    {
                                        Settings.gameManager.cardToAttack.isFlatfooted = true;
                                        Settings.gameManager.cardToAttack.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
                                    }

                                    if (Int16.Parse(Settings.gameManager.cardToAttack.viz.properties[attackerHP].text.text) <= 0)
                                    {
                                        Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + "'s " +
                                            Settings.gameManager.cardToAttack.viz.card.name +
                                         " killed ", Settings.gameManager.currentPlayer.playerColor);

                                        Settings.gameManager.currentPlayer.graveyard_cards.Add(Settings.gameManager.cardToAttack.viz.card.name);

                                        if (Settings.gameManager.currentPlayer.cardsDown.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown1.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown1.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown2.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown2.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown3.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown3.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown4.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown4.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown5.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown5.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown6.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown6.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown7.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown7.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown8.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown8.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDown9.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDown9.Remove(Settings.gameManager.cardToAttack);



                                        if (Settings.gameManager.currentPlayer.cardsDownB.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDownB.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDownB1.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDownB1.Remove(Settings.gameManager.cardToAttack);

                                        if (Settings.gameManager.currentPlayer.cardsDownB2.Contains(Settings.gameManager.cardToAttack))
                                            Settings.gameManager.currentPlayer.cardsDownB2.Remove(Settings.gameManager.cardToAttack);









                                        Destroy(Settings.gameManager.cardToAttack.gameObject);
                                    }

                                    if (Int16.Parse(inst.viz.properties[attackedHP].text.text) <= 0)
                                    {

                                        if (inst.viz.card.cardType.name == "Troop")
                                            Settings.RegisterEvent(Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].username + "'s " +
                                           inst.viz.card.name + " killed", Settings.gameManager.currentPlayer.playerColor);
                                        else Settings.RegisterEvent(Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].username + "'s " +
                                          inst.viz.card.name + " destoryed", Settings.gameManager.currentPlayer.playerColor);

                                        Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].graveyard_cards.Add(inst.viz.card.name);

                                        if (p.cardsDown.Contains(inst))
                                            p.cardsDown.Remove(inst);

                                        if (p.cardsDown1.Contains(inst))
                                            p.cardsDown1.Remove(inst);

                                        if (p.cardsDown2.Contains(inst))
                                            p.cardsDown2.Remove(inst);

                                        if (p.cardsDown3.Contains(inst))
                                            p.cardsDown3.Remove(inst);

                                        if (p.cardsDown4.Contains(inst))
                                            p.cardsDown4.Remove(inst);

                                        if (p.cardsDown5.Contains(inst))
                                            p.cardsDown5.Remove(inst);

                                        if (p.cardsDown6.Contains(inst))
                                            p.cardsDown6.Remove(inst);

                                        if (p.cardsDown7.Contains(inst))
                                            p.cardsDown7.Remove(inst);

                                        if (p.cardsDown8.Contains(inst))
                                            p.cardsDown8.Remove(inst);

                                        if (p.cardsDown9.Contains(inst))
                                            p.cardsDown9.Remove(inst);



                                        if (p.cardsDownB.Contains(inst))
                                            p.cardsDownB.Remove(inst);

                                        if (p.cardsDownB1.Contains(inst))
                                            p.cardsDownB1.Remove(inst);

                                        if (p.cardsDownB2.Contains(inst))
                                            p.cardsDownB2.Remove(inst);



                                        Destroy(inst.gameObject);
                                    }

                                    Settings.gameManager.cardToAttack = null;


                                }



                        }
                        else
                        {

                            if (Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].playerCard == inst
                                && Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].NrTroops() == 0
                                && Settings.gameManager.cardToAttack != null)
                            {

                                int damage = 0;

                                for (int i = 0; i < Settings.gameManager.cardToAttack.viz.properties.Length; i++)
                                {

                                    if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "Attack")
                                    {
                                        Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].health -=
                                            Int16.Parse(Settings.gameManager.cardToAttack.viz.properties[i].text.text);
                                        damage = Int16.Parse(Settings.gameManager.cardToAttack.viz.properties[i].text.text);
                                    }

                                }

                                Settings.gameManager.statsUI[1].health.text =
                                    Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].health.ToString();

                                Settings.gameManager.statsUI[1].maxHealth.text =
                                    Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].maxHealth.ToString();




                                Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + "'s " +
                                    Settings.gameManager.cardToAttack.viz.card.name + " hit " +
                                    Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].username +
                                    " for " + damage + " damage"
                                     , Settings.gameManager.currentPlayer.playerColor);




                                Debug.Log(Settings.gameManager.currentPlayer.username + "'s " +
                                    Settings.gameManager.cardToAttack.viz.card.name + " hit " +
                                    Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].username +
                                    " for " + damage + " damage");

                                Settings.gameManager.cardToAttack.viz.card.ExecuteOnThisAttacks();
                                Settings.gameManager.cardToAttack.viz.card.ExecuteOnThisHitsEnemy();

                                Settings.gameManager.cardToAttack.nrAttacksDone++;

                                if (Settings.gameManager.cardToAttack.nrAttacksDone >= Settings.gameManager.cardToAttack.viz.card.nrAttacks)
                                {
                                    Settings.gameManager.cardToAttack.isFlatfooted = true;

                                    Settings.gameManager.cardToAttack.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
                                }



                                Settings.gameManager.cardToAttack = null;

                            }




                        }



                    }


                }
                else
                {
                    Settings.gameManager.cardToAttack = null;


                    if (inst.viz.card.cardType.name=="Troop")
                        if (inst.CanAttack()==true && inst.viz.card.canAttack == true) Settings.gameManager.cardToAttack = inst;

                    if (inst.viz.card.cardType.name == "Building")
                    {
                        if (!inst.isFlatfooted && inst.viz.card.canAttack)
                        {
                            Settings.gameManager.selectedOption = -50;
                            inst.isFlatfooted = true;
                            inst.transform.eulerAngles = new Vector3(0, 0, 90);
                            inst.viz.card.ExecuteAbility(inst);
                        }
                    }


                }



                /*
                for (int i = 0; i < inst.viz.properties.Length; i++)
                    if (inst.viz.properties[i].element.name == "Cost")
                        Debug.Log("FOUND COST as " + inst.viz.properties[i].text.text + " MANA");
                */

            }
            else
            {
               
                    Settings.gameManager.cardToAttack = inst;


            }


        }


        public override void OnHighlight(CardInstance inst)
        {

            int HP = -1, P = -1;

            for (int i = 0; i < inst.viz.properties.Length; i++)
            {
                if (inst.viz.properties[i].element.name == "HP")
                {
                    HP = i;
                }

                if (inst.viz.properties[i].element.name == "Attack")
                {
                    P = i;
                }

            }


            if (P != -1) Debug.Log(inst.viz.card.name + " " + inst.viz.properties[HP].text.text + " HP " +
                     inst.viz.properties[P].text.text + " P ");
            else Debug.Log(inst.viz.card.name + " " + inst.viz.properties[HP].text.text + " HP ");


        }



        public void SpecialInteraction(CardInstance attacker, CardInstance attacked, ref int damage)
        {


            if (attacked.viz.card.name == "Anti-meme")
            {

                for (int i = 0; i < attacker.viz.card.properties.Length; i++)
                {
                    if (attacker.viz.card.properties[i].element.name == "Class")
                    {
                        if (attacker.viz.card.properties[i].StringValue == "Meme")
                            damage = 0;

                    }

                }

            }










        }





    }


}