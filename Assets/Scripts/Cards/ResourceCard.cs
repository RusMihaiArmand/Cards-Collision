using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Cards/Resource")]
    public class ResourceCard : CardType
    {

        public override void OnSetType(CardViz viz)
        {
            base.OnSetType(viz);

            viz.statsHolderP.SetActive(false);
            viz.statsHolderHP.SetActive(false);

        }



    }
}