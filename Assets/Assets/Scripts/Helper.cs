using UnityEngine;
using System.Collections;

public class Helper : BaseCharacters {
    
    public int _Gold; //Cash the person gives to the player(to execute a task if its a questgiver)

    //Constructors
    
    public Helper()
    {
        _Gold = 5;
    }

    public Helper(string name, int gold) : base(name)
    {
        _Gold = gold;
    }
}
