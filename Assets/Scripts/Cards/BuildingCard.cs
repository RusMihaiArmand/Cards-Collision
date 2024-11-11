﻿using UnityEngine;
using System.Collections;


namespace SA
{
    [CreateAssetMenu(menuName ="Cards/Building")]
    public class BuildingCard : CardType
    {

        public override void OnSetType(CardViz viz)
        {

            base.OnSetType(viz);

            viz.statsHolderP.SetActive(false);
            viz.statsHolderHP.SetActive(true);

        }


    }
}