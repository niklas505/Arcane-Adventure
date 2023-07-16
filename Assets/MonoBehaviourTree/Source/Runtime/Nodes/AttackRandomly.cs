using UnityEngine;
using MBT;

namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "fight/AttackRandomly")]
  public class AttackRandomly : Leaf
  {
      // These two methods are optional, override only when needed
      // public override void OnAllowInterrupt() {}
      // public override void OnEnter() {}

      // This is called every tick as long as node is executed
      public override NodeResult Execute()
      {
          Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();

          Vector2IntVariable posVar = blackboard.GetVariable<Vector2IntVariable>("position");
          Vector2IntVariable dirVar = blackboard.GetVariable<Vector2IntVariable>("direction");

          posVar.Value = posVar.Value + dirVar.Value;

          return NodeResult.success;
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

  }
}