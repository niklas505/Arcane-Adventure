using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MBT
{
    [AddComponentMenu("")]
    public class TilemapVariable : Variable<Tilemap>
    {
        protected override bool ValueEquals(Tilemap val1, Tilemap val2)
        {
            return val1 == val2;
        }
    }  

    [System.Serializable]
    public class TilemapReference : VariableReference<TilemapVariable, Tilemap>
    {
        public TilemapReference(VarRefMode mode = VarRefMode.EnableConstant)
        {
            SetMode(mode);
        }
        
        public TilemapReference(Tilemap defaultConstant)
        {
            useConstant = true;
            constantValue = defaultConstant;
        }
        
        public Tilemap Value
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
