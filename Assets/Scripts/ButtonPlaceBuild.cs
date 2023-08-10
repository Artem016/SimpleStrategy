using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{
    public GameObject building;

    public void PlaceBuild()
    {
        Instantiate(building,new Vector3(0, 4.5f, 0), Quaternion.identity);
    }
}
