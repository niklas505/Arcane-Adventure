using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;


namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "Conditions/RoomCondition")]
  public class RoomCondition: Condition
  {
     public Abort abort;
     public Comparator comparator = Comparator.Equal;
     public IntReference intToCompare = new IntReference(0);

     public override bool Check()
        {
            Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
            IntVariable createdRooms = blackboard.GetVariable<IntVariable>("createdRooms");

            switch (comparator)
                {
                    case Comparator.Equal:
                        return createdRooms.Value == intToCompare.Value;
                    case Comparator.GreaterThan:
                        return createdRooms.Value > intToCompare.Value;
                    case Comparator.LessThan:
                        return createdRooms.Value < intToCompare.Value;
                }
                
            return false;
        }

     public override void OnAllowInterrupt()
        {   
            Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
            IntVariable createdRooms = blackboard.GetVariable<IntVariable>("createdRooms");
            
            if (abort != Abort.None)
            {
                ObtainTreeSnapshot();
                createdRooms.AddListener(OnVariableChange);
                if (!intToCompare.isConstant)
                {
                    intToCompare.GetVariable().AddListener(OnVariableChange);
                }
                    
                
            }
        }   
     
     public override void OnDisallowInterrupt()
        {
            Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
            IntVariable createdRooms = blackboard.GetVariable<IntVariable>("createdRooms");

            if (abort != Abort.None)
            {
                createdRooms.RemoveListener(OnVariableChange);
                if (!intToCompare.isConstant)
                {
                    intToCompare.GetVariable().RemoveListener(OnVariableChange);
                }    
            
            }
        }

     private void OnVariableChange(int newVal, int oldVal)
        {
            EvaluateConditionAndTryAbort(abort);
        }
     
      public override bool IsValid()
        {
            return !(intToCompare.isInvalid);
        }

     public enum Comparator
        {
            [InspectorName("==")]
            Equal, 
            [InspectorName(">")]
            GreaterThan, 
            [InspectorName("<")]
            LessThan
        }
      
      
      
  }
}
