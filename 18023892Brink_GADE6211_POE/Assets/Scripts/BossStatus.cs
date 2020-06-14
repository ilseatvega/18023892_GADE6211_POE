using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    //status bool to determine if boss is active
    private bool status = false;
    //bool get set that can return the status or set status to a value
    public bool Status { get { return status; } set { status = value; } }
}
