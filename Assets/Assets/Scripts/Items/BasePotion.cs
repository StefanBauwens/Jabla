using UnityEngine;
using System.Collections;

public class BasePotion : BaseItem {

	public enum PotionTypes
    {
        TIMECHANGER, // instead of getting more time, you'll get less
        QUESTCOMPLETER, // you'll get nothing out of it
        SPEED //decrease your movement speed
    }

    protected PotionTypes _potionTypes;
    
    public PotionTypes potionType
    {
        get { return _potionTypes; }
        set { _potionTypes = value; }
    }
}
