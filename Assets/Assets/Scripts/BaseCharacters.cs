using UnityEngine;
using System.Collections;


public class BaseCharacters : MonoBehaviour {

    //fields
    public string _Name;
    public TextAsset _Text;
    

    //Constructors
    public BaseCharacters() //base constructor
    {
        _Name = "John Smith";
        
    }

    public BaseCharacters(string name)
    {
        _Name = name;
        
    }


    /*properties not being used because constructors
    public string Name
    {
        get
        {
            return mName;
        }
        set
        {
            mName = value;
        }
    }*/

    //Methods

}
