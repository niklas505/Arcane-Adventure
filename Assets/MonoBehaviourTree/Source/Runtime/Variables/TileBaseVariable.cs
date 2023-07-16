using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MBT
{
    [AddComponentMenu("")]
    public class TileBaseVariable : Variable<TileBase>
    {
        protected override bool ValueEquals(TileBase val1, TileBase val2)
        {
            return val1 == val2;
        }
    }  

    [System.Serializable]
    public class TileBaseReference : VariableReference<TileBaseVariable, TileBase>
    {
        public TileBaseReference(VarRefMode mode = VarRefMode.EnableConstant)
        {
            SetMode(mode);
        }
        
        public TileBaseReference(TileBase defaultConstant)
        {
            useConstant = true;
            constantValue = defaultConstant;
        }
        
        public TileBase Value
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
