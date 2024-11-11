using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SA
{
    public class PlayerStatsUI : MonoBehaviour
    {
        public PlayerHolder player;

        public Image head;
        public Image eyes;
        public Image beard;
        public Image ears;
        public Image eyebrows;
        public Image hat;
        public Image moustache;
        public Image mouth;
        public Image nose;

        public Text health;
        public Text maxHealth;

        public Text mana;

        public Text userName;

        public Text nrCards;
        

        public void UpdateAll()
        {
            UpdateHealth();
            UpdateMana();
            UpdateUsername();

            nrCards.text = player.all_cards.Count.ToString();

        }

        public void UpdateUsername()
        {
            userName.text = player.username;


            head.sprite = player.head;
            eyes.sprite = player.eyes;
            beard.sprite = player.beard;
            ears.sprite = player.ears;
            eyebrows.sprite = player.eyebrows;
            hat.sprite = player.hat;
            moustache.sprite = player.moustache;
            mouth.sprite = player.mouth;
            nose.sprite = player.nose;


        }


        public void UpdateHealth()
        {
            health.text = player.health.ToString();
            maxHealth.text = player.maxHealth.ToString();
        }


        public void UpdateMana()
        {
            mana.text = player.mana.ToString();

        }



    }
}