using UnityEngine;
using System.Collections;


public class BaseCharacters : MonoBehaviour {

    //fields
    [SerializeField] //protected variables will appear in editor Unity
    protected string _Name;
    

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
