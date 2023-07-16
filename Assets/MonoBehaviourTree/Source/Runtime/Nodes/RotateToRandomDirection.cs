using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "PCG/RotateToRandomDirection")]
  public class RotateToRandomDirection : Leaf
  {
      // These two methods are optional, override only when needed
      // public override void OnAllowInterrupt() {}
      // public override void OnEnter() {}

      // This is called every tick as long as node is executed
      public override NodeResult Execute()
      {
          Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();

          Vector2IntVariable dirVar = blackboard.GetVariable<Vector2IntVariable>("direction");
          List<Vector2Int> directions = new List<Vector2Int>{Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.left};

          dirVar.Value = directions[(Random.Range(0, 4))];

          return NodeResult.success;
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

  }
}