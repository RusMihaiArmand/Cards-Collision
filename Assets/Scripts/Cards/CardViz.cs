﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace SA
{
    public class CardViz : MonoBehaviour
    {
        public Card card;
        public CardVizProperties[] properties;
        public GameObject statsHolderP, statsHolderHP;




        public void LoadCard(Card c)
        {

            if (c == null) return;

            card = c;


            c.cardType.OnSetType(this);


            CloseAll();


            for (int i=0; i < c.properties.Length; i++)
            {
                CardProperties cp = c.properties[i];


                CardVizProperties p = GetProperty(cp.element);

                if (p == null) continue;


                if (cp.element is ElementInt)
                {
                    p.text.text = cp.intValue.ToString();
                    p.text.gameObject.SetActive(true);

                }
                else
                {
                    if (cp.element is ElementText)
                    {
                        p.text.text = cp.StringValue;
                        p.text.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (cp.element is ElementImage)
                        {
                            p.img.sprite = cp.sprite;
                            p.img.gameObject.SetActive(true);
                        }
                    }
                }
            }

        }


        public void CloseAll()
        {

            foreach (CardVizProperties p in properties)
            {
                if (p.img != null)
                    p.img.gameObject.SetActive(false);

                if (p.text != null)
                { p.text.gameObject.SetActive(false);

                    p.text.text = "0";

                }

            }


        }



        public CardVizProperties GetProperty(Element e)
        {
            CardVizProperties result = null;

            for (int i=0; i< properties.Length; i++)
            {
                if(properties[i].element==e)
                {
                    result = properties[i];
                    break;

                }
            }


            return result;
        }



    }
}