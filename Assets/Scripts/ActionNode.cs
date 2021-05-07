using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    // method signature for the action
    public delegate NodeStates ActionNodeDelegate();

    // delegate that is called to evaluate this node
    private ActionNodeDelegate m_action;

    // because this node contains no logic itself, the logic must be passed in in the form of a delegate.
    // as the signature states, the action needs to return a NodeStates enum
    public ActionNode(ActionNodeDelegate action){
        m_action = action;
    }

    // evaluates the node using the passed in delegate and 
    // reports the resulting state as appropriate
    public override NodeStates Evaluate()
    {
        switch(m_action()){
            case NodeStates.SUCCESS:
            m_nodeState = NodeStates.SUCCESS;
            return m_nodeState;
            case NodeStates.FAILURE:
            m_nodeState = NodeStates.FAILURE;
            return m_nodeState;
            case NodeStates.RUNNING:
            m_nodeState = NodeStates.RUNNING;
            return m_nodeState;
            default:
            m_nodeState = NodeStates.FAILURE;
            return m_nodeState;
        }
    }
}
