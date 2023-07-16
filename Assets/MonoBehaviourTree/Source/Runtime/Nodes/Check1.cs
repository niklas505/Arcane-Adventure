using UnityEngine;
using MBT;

namespace MBT
{
    // Empty Menu attribute prevents Node to show up in "Add Component" menu.
    [AddComponentMenu("")]
    // Register node in visual editor node finder
    [MBTNode(name = "fight/Check1")]
    public class Check1 : Condition {
        // These two methods are optional, override only when needed
        // public override void OnAllowInterrupt() {}
        // public override void OnEnter() {}

        // This is called every tick as long as node is executed


        // These two methods are optional, override only when needed
        // public override void OnExit() {}
        // public override void OnDisallowInterrupt() {}
        public override bool Check() {
            throw new System.NotImplementedException();
        }
    }
}