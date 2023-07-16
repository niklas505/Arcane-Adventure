using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "PCG/SmartRotateToRndmDir")]
  public class SmartRotateToRndmDir : Leaf
  {

      
      // These two methods are optional, override only when needed
      // public override void OnAllowInterrupt() {}
      // public override void OnEnter() {}

      // This is called every tick as long as node is executed
      public override NodeResult Execute()
      {
          Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();

          Vector2Int[] directionsAfterUp = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.right, Vector2Int.left};
          Vector2Int[] directionsAfterDown = {Vector2Int.right, Vector2Int.left, Vector2Int.down, Vector2Int.right, Vector2Int.left};
          Vector2Int[] directionsAfterLeft = {Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.up, Vector2Int.down};
          Vector2Int[] directionsAfterRight = {Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.up, Vector2Int.down};

          Vector2IntVariable dirVar = blackboard.GetVariable<Vector2IntVariable>("direction");
          Vector2Int currentDir = dirVar.Value;
          
          
          if (currentDir == Vector2Int.up) {
            dirVar.Value = directionsAfterUp[(Random.Range(0, directionsAfterUp.Length))];
          } else if (currentDir == Vector2Int.down) {
            dirVar.Value = directionsAfterDown[(Random.Range(0, directionsAfterDown.Length))];
          } else if (currentDir == Vector2Int.left) {
            dirVar.Value = directionsAfterLeft[(Random.Range(0, directionsAfterLeft.Length))];
          } else {
            dirVar.Value = directionsAfterRight[(Random.Range(0, directionsAfterRight.Length))];
          }

          return NodeResult.success;
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

  }
}