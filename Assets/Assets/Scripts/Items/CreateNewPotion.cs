using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

    protected BasePotion newPotion;

	// Use this for initialization
	void Start () {
        CreatePotion();
        Debug.Log(newPotion.itemName);
        Debug.Log(newPotion.itemDescription);
        Debug.Log(newPotion.potionType.ToString());
    }
	//methods
    public void CreatePotion()
    {
        newPotion = new BasePotion(); 
        newPotion.itemName = "Potion"; 
        newPotion.itemDescription = "The potion that will ruin your life.";
        newPotion.potionType = BasePotion.PotionTypes.TIMECHANGER; // set potiontype
    }

    
	
}
