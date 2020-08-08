using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBossStatus : MonoBehaviour
{
    //status bool to determine if boss is active
    private bool iceStatus = false;
    //bool get set that can return the status or set status to a value
    public bool IceStatus { get { return iceStatus; } set { iceStatus = value; } }
}
