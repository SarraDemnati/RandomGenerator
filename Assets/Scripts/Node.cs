using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 worldPositon;
    public bool isWalkeable;
    public int gCost;
    public int hCost;
    public Node parent;
    public int fCost { get { return gCost + hCost; } }

    public Node(Vector3 _worldPos, bool _isWalkable)
    {
        worldPositon = _worldPos;
        isWalkeable = _isWalkable;
    }
}
