using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MonoBehaviourTree))]
    public class MBTExecutor : MonoBehaviour
    {
        public MonoBehaviourTree monoBehaviourTree;

        [SerializeField]
        private int ticksPerFrame = 1;

        void Reset()
        {
            monoBehaviourTree = GetComponent<MonoBehaviourTree>();
            OnValidate();
        }

        void Update()
        {
            for (int i = 0; i < ticksPerFrame; i++) {
                monoBehaviourTree.Tick();
            }
        }

        void OnValidate()
        {
            if (monoBehaviourTree != null && monoBehaviourTree.parent != null)
            {
                monoBehaviourTree = null;
                Debug.LogWarning("Subtree should not be target of update. Select parent tree instead.", this.gameObject);
            }
        }
    }
}
