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
  [MBTNode(name = "PCG/CreateRoom")]
  public class CreateRoom : Leaf
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
          IntVariable createdRooms = blackboard.GetVariable<IntVariable>("createdRooms");

          (int, int) roomSize = GetRandomRoomSize();
          int stepSizeVertical = (roomSize.Item1 / 2) + 1;
          int stepSizeHorizontal = (roomSize.Item2 / 2) + 1;
          Vector2Int buildPos = pos;

          //upper left quarter
          for (int i = 0; i <= stepSizeVertical; i++) {
              for (int j = 0; j <= stepSizeHorizontal; j++) {
                  if (i == stepSizeVertical || j == stepSizeHorizontal) {
                      if (!map.HasTile((Vector3Int) buildPos)) {
                          map.SetTile((Vector3Int) buildPos, wallTile);
                      }
                  } else {
                      map.SetTile((Vector3Int) buildPos, floorTile);
                  }
                  buildPos = buildPos + Vector2Int.left;
              }
              buildPos = buildPos + Vector2Int.up;
              buildPos.x = pos.x;
          }
          
          buildPos = pos;
          //bottom left quarter
          for (int i = 0; i <= stepSizeVertical; i++) {
              for (int j = 0; j <= stepSizeHorizontal; j++) {
                  if (i == stepSizeVertical || j == stepSizeHorizontal) {
                      if (!map.HasTile((Vector3Int) buildPos)) {
                          map.SetTile((Vector3Int) buildPos, wallTile);
                      }
                  } else {
                      map.SetTile((Vector3Int) buildPos, floorTile);
                  }
                  buildPos = buildPos + Vector2Int.left;
              }
              buildPos = buildPos + Vector2Int.down;
              buildPos.x = pos.x;
          }

          buildPos = pos;
          //upper right quarter
          for (int i = 0; i <= stepSizeVertical; i++) {
              for (int j = 0; j <= stepSizeHorizontal; j++) {
                  if (i == stepSizeVertical || j == stepSizeHorizontal) {
                      if (!map.HasTile((Vector3Int) buildPos)) {
                          map.SetTile((Vector3Int) buildPos, wallTile);
                      }
                  } else {
                      map.SetTile((Vector3Int) buildPos, floorTile);
                  }
                  buildPos = buildPos + Vector2Int.right;
              }
              buildPos = buildPos + Vector2Int.up;
              buildPos.x = pos.x;
          }

          buildPos = pos;
          //bottom right quarter
          for (int i = 0; i <= stepSizeVertical; i++) {
              for (int j = 0; j <= stepSizeHorizontal; j++) {
                  if (i == stepSizeVertical || j == stepSizeHorizontal) {
                      if (!map.HasTile((Vector3Int) buildPos)) {
                          map.SetTile((Vector3Int) buildPos, wallTile);
                      }
                  } else {
                      map.SetTile((Vector3Int) buildPos, floorTile);
                  }
                  buildPos = buildPos + Vector2Int.right;
              }
              buildPos = buildPos + Vector2Int.down;
              buildPos.x = pos.x;
          }

          createdRooms.Value += 1;
          
          return NodeResult.success;
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

      
      private (int, int) GetRandomRoomSize() {
        (int, int)[] roomSizes = new (int, int)[] {(9, 9), (15, 7), (13, 9), (7, 11), (7, 15), (9, 13), (11, 7)};
        return roomSizes[Random.Range(0, roomSizes.Length)];
      }
  }
}