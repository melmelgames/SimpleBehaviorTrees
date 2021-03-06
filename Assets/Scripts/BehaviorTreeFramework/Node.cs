using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node 
{
    // Delegate that returns the state of the node
    public delegate NodeStates NodeReturn();

    // The current state of the node
    protected NodeStates m_nodeState;

    public NodeStates nodeState{
        get { return m_nodeState; }
    }

    // constructor for the node
    public Node(){}

    // implementing classes use this method to evaluate the desired set of conditions
    public abstract NodeStates Evaluate();

}
