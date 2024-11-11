using UnityEngine;
using System.Collections;


namespace SA
{
    [CreateAssetMenu(menuName ="Cards/Troop")]
    public class TroopCard : CardType
    {

        public override void OnSetType(CardViz viz)
        {

            base.OnSetType(viz);

            viz.statsHolderP.SetActive(true);
            viz.statsHolderHP.SetActive(true);

        }


    }
}