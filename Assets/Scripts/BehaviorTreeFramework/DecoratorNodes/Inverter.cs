using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    // child node to evaluate
    private Node m_node;

    public Node node{
        get { return m_node;}
    }

    // constructor requires the child node that this inverter decorator wraps
    public Inverter(Node node){
        m_node = node;
    }

    // reports a success if the child fails, and failure if the child reports success
    // running will report as running
    public override NodeStates Evaluate()
    {
        switch(m_node.Evaluate()){
            case NodeStates.FAILURE:
            m_nodeState = NodeStates.SUCCESS;
            return m_nodeState;
            case NodeStates.SUCCESS:
            m_nodeState = NodeStates.FAILURE;
            return m_nodeState;
            case NodeStates.RUNNING:
            m_nodeState = NodeStates.RUNNING;
            return m_nodeState;
        }
        m_nodeState = NodeStates.SUCCESS;
        return m_nodeState;
    }
}
