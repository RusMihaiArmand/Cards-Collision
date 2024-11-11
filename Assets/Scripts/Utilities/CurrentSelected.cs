using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class CurrentSelected : MonoBehaviour
    {
        public CardVariable currentCard;
        public CardViz cardViz;

        Transform mTransform;

        public void LoadCard()
        {
            if (currentCard.value == null)
                return;

            currentCard.value.gameObject.SetActive(false);
            cardViz.LoadCard(currentCard.value.viz.card);
            cardViz.gameObject.SetActive(true);






            int powervalue, hpvalue, costvalue;
            powervalue = -1; hpvalue = -1; costvalue = -1;

            for (int i = 0; i < Settings.gameManager.copyCard.viz.properties.Length; i++)
            {
                if (Settings.gameManager.copyCard.viz.properties[i].element.name == "HP")
                {
                    hpvalue = i;
                }

                if (Settings.gameManager.copyCard.viz.properties[i].element.name == "Attack")
                {
                    powervalue = i;
                }


                if (Settings.gameManager.copyCard.viz.properties[i].element.name == "Cost")
                {
                    costvalue = i;
                }


            }



            for (int i = 0; i < cardViz.properties.Length; i++)
            {
                if (cardViz.properties[i].element.name == "HP")
                {
                    if (hpvalue != -1)
                        cardViz.properties[i].text.text =
                            Settings.gameManager.copyCard.viz.properties[hpvalue].text.text;
                }

                if (cardViz.properties[i].element.name == "Attack")
                {
                    if (powervalue != -1)
                        cardViz.properties[i].text.text =
                            Settings.gameManager.copyCard.viz.properties[powervalue].text.text;
                }


                if (cardViz.properties[i].element.name == "Cost")
                {
                    if (costvalue != -1)
                        cardViz.properties[i].text.text =
                            Settings.gameManager.copyCard.viz.properties[costvalue].text.text;
                }


            }









        }

        public void CloseCard()
        {
            cardViz.gameObject.SetActive(false);


        }

        public void Start()
        {
            mTransform = this.transform;
            CloseCard();
        }


        void Update()
        {
            mTransform.position = Input.mousePosition;
        }



    }
}