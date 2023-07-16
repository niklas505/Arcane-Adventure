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
  [MBTNode(name = "PCG/CreateTile")]
  public class CreateFloor : Leaf
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
          TileBase floorTile = blackboard.GetVariable<TileBaseVariable>("floorTile").Value;
          TileBase wallTile = blackboard.GetVariable<TileBaseVariable>("wallTile").Value;
          
          Vector2Int left = pos + Vector2Int.left;
          Vector2Int upperLeft = pos + Vector2Int.left + Vector2Int.up;
          Vector2Int up = pos + Vector2Int.up;
          Vector2Int upperRight = pos + Vector2Int.right + Vector2Int.up;
          Vector2Int right = pos + Vector2Int.right;
          Vector2Int bottom = pos + Vector2Int.down;
          Vector2Int bottomLeft = pos + Vector2Int.left + Vector2Int.down;
          Vector2Int bottomRight = pos + Vector2Int.right + Vector2Int.down;
          Vector2Int wallPos = pos + (2 * Vector2Int.down) + (2 * Vector2Int.left);

          //build floor
          if (CanPlaceFloorAt(pos)) {
            map.SetTile((Vector3Int) pos, floorTile);
          }
          if (CanPlaceFloorAt(left)) {
            map.SetTile((Vector3Int) left, floorTile);
          }
          if (CanPlaceFloorAt(upperLeft)) {
            map.SetTile((Vector3Int) upperLeft, floorTile);
          }
          if (CanPlaceFloorAt(up)) {
            map.SetTile((Vector3Int) up, floorTile);
          }
          if (CanPlaceFloorAt(upperRight)) {
            map.SetTile((Vector3Int) upperRight, floorTile);
          }
          if (CanPlaceFloorAt(right)) {
            map.SetTile((Vector3Int) right, floorTile);
          }
          if (CanPlaceFloorAt(bottom)) {
            map.SetTile((Vector3Int) bottom, floorTile);
          }
          if (CanPlaceFloorAt(bottomLeft)) {
            map.SetTile((Vector3Int) bottomLeft, floorTile);
          }
          if (CanPlaceFloorAt(bottomRight)) {
            map.SetTile((Vector3Int) bottomRight, floorTile);
          }
         
          //build wall
          for (int i = 1; i <= 4; i++) {
            wallPos = wallPos + Vector2Int.up;
            if (!map.HasTile((Vector3Int) wallPos)) {
                map.SetTile((Vector3Int) wallPos, wallTile);
            }
          }
          for (int i = 1; i <= 4; i++) {
            wallPos = wallPos + Vector2Int.right;
            if (!map.HasTile((Vector3Int) wallPos)) {
                map.SetTile((Vector3Int) wallPos, wallTile);
            }
          }
          for (int i = 1; i <= 4; i++) {
            wallPos = wallPos + Vector2Int.down;
            if (!map.HasTile((Vector3Int) wallPos)) {
                map.SetTile((Vector3Int) wallPos, wallTile);
            }
          }
          for (int i = 1; i <= 4; i++) {
            wallPos = wallPos + Vector2Int.left;
            if (!map.HasTile((Vector3Int) wallPos)) {
                map.SetTile((Vector3Int) wallPos, wallTile);
            }
          }

          return NodeResult.success;
      }

      private bool CanPlaceFloorAt(Vector2Int pos) {
        Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
        Tilemap map = blackboard.GetVariable<TilemapVariable>("map").Value;
        
        return (!map.HasTile((Vector3Int) pos) || map.GetTile((Vector3Int) pos).name != "CreatureTile");
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

  }
}