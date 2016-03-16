using UnityEngine;
using System.Collections;

public class Potion : BaseItem {

    public string itemName;
    public string itemDescription;
    public potionTypes types;

	public enum potionTypes
    {
        Timechanger, // instead of getting more time, you'll get less
        Questcompleter, // you'll get nothing out of it
        Speed //decrease your movement speed
    }
    
    public Potion(string name, string description): base(name, description)
    {
        itemName = name;
        itemDescription = description;
    }


    void Start()
    {
        
    }

    void Update()
    {
        if (types == potionTypes.Timechanger)
        {
            TimeDecreaser(Timer.changeTime);
        }
        else if (types == potionTypes.Questcompleter)
        {

        }
        else if (types == potionTypes.Speed)
        {

        }
        Debug.Log(Timer.changeTime);
    }

    float TimeDecreaser(float time)
    {
        float decreasedTime;
        decreasedTime = time - 2;
        return decreasedTime;
    }
}
