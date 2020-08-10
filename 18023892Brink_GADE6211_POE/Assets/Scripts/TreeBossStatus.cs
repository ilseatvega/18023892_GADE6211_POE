using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossStatus : MonoBehaviour
{
    //status bool to determine if boss is active
    private bool treeStatus = false;
    //bool get set that can return the status or set status to a value
    public bool TreeStatus { get { return treeStatus; } set { treeStatus = value; } }
}
