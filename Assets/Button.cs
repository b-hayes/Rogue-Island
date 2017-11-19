using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public void button(string name)
    {
		Data.resetIslands();
        Scenes.SwitchScene(name);
    }
}
