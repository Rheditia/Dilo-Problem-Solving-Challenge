using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGizmos : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
