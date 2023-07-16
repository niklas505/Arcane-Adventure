using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;
using UnityEngine.Tilemaps;

namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "PCG/CreateCreature")]
  public class CreateCreature : Leaf
  {
      // These two methods are optional, override only when needed
      // public override void OnAllowInterrupt() {}
      // public override void OnEnter() {}

      // This is called every tick as long as node is executed
      public override NodeResult Execute()
      {
          Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
          
          Vector2Int pos = blackboard.GetVariable<Vector2IntVariable>("position").Value;
          Tilemap map = blackboard.GetVariable<TilemapVariable>("map").Value;
          TileBase creatureTile = blackboard.GetVariable<TileBaseVariable>("creatureTile").Value;
          
          Vector2Int spawnPos = pos + RandomDir() * (int) Random.Range(1,3);
          map.SetTile((Vector3Int) spawnPos, creatureTile);

          return NodeResult.success;
      }

      private Vector2Int RandomDir() {
        Vector2Int upperLeft = Vector2Int.up + Vector2Int.left;
        Vector2Int upperRight = Vector2Int.up + Vector2Int.right;
        Vector2Int lowerLeft = Vector2Int.down + Vector2Int.left;
        Vector2Int lowerRight = Vector2Int.down + Vector2Int.right;
        Vector2Int up = Vector2Int.up;
        Vector2Int low = Vector2Int.down;
        Vector2Int left = Vector2Int.left;
        Vector2Int right = Vector2Int.right;
        Vector2Int[] directions = {upperLeft, upperRight, lowerLeft, lowerRight, up, low, left, right};

        return directions[Random.Range(0, directions.Length)];
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

      
      
  }
}
