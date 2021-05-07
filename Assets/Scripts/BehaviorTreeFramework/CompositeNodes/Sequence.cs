using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    // children nodes that belong to this sequence
    private List<Node> m_nodes = new List<Node>();

    // must provide an initial set of children nodes to work
    public Sequence(List<Node> nodes){
        m_nodes = nodes;
    }

    // if any child node returns a failure, the entire node fails
    // if all children nodes returns a success, the node reports a success
    public override NodeStates Evaluate()
    {
        bool anyChildRunning = false;
        foreach(Node node in m_nodes){
            switch(node.Evaluate()){
                case NodeStates.FAILURE:
                m_nodeState = NodeStates.FAILURE;
                return m_nodeState;
                case NodeStates.SUCCESS:
                continue;
                case NodeStates.RUNNING:
                anyChildRunning = true;
                continue;
                default:
                m_nodeState = NodeStates.SUCCESS;
                return m_nodeState;
            }
        }
        m_nodeState = anyChildRunning ? NodeStates.RUNNING : NodeStates.SUCCESS;
        return m_nodeState;
    }
}
