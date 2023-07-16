using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [AddComponentMenu("")]
    public class Vector2IntVariable : Variable<Vector2Int>
    {
        protected override bool ValueEquals(Vector2Int val1, Vector2Int val2)
        {
            return val1 == val2;
        }
    }  

    [System.Serializable]
    public class Vector2IntReference : VariableReference<Vector2IntVariable, Vector2Int>
    {
        public Vector2IntReference(VarRefMode mode = VarRefMode.EnableConstant)
        {
            SetMode(mode);
        }
        
        public Vector2IntReference(Vector2Int defaultConstant)
        {
            useConstant = true;
            constantValue = defaultConstant;
        }
        
        public Vector2Int Value
        {
            get
            {
                return (useConstant)? constantValue : this.GetVariable().Value;
            }
            set
            {
                if (useConstant)
                {
                    constantValue = value;
                }
                else
                {
                    this.GetVariable().Value = value;
                }
            }
        }
        
    }

}
