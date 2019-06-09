using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace Attributes
{
    [Serializable]
    public class Attribute
    {
        public float BaseValue;
        public readonly ReadOnlyCollection<AttributeModifier> AttributeModifiers;

        protected float lastBaseValue;
        protected bool isDirty = true;
        protected float _value;

        protected readonly List<AttributeModifier> attributeModifiers;

        public float Value
        {
            get
            {
                if (isDirty || lastBaseValue != BaseValue)
                {
                    Debug.Log("Lastbasevalue: " + lastBaseValue + "basevalue: " + BaseValue);
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                    Debug.Log("Value calculated" + _value);
                }
                return _value;
            }
        }

        public Attribute()
        {
            attributeModifiers = new List<AttributeModifier>();
            AttributeModifiers = attributeModifiers.AsReadOnly();
        }

        public Attribute(float baseValue) : this()
        {
            BaseValue = baseValue;
        }


        public virtual void AddModifier(AttributeModifier mod)
        {
            isDirty = true;
            attributeModifiers.Add(mod);
            attributeModifiers.Sort(CompareModifierOrder);
        }


        public virtual bool RemoveModifier(AttributeModifier mod)
        {
            if (attributeModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }


        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;

            for (int i = attributeModifiers.Count - 1; i >= 0; i--)
            {
                if (attributeModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    attributeModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }


        protected virtual int CompareModifierOrder(AttributeModifier a, AttributeModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0; // if (a.Order == b.Order)
        }


        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercent = 0;

            for (int i = 0; i < attributeModifiers.Count; i++)
            {
                AttributeModifier mod = attributeModifiers[i];

                if (mod.Type == AttributeModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == AttributeModType.Percent)
                {
                    sumPercent += mod.Value;

                    if (i + 1 >= attributeModifiers.Count || attributeModifiers[i + 1].Type != AttributeModType.Percent)
                    {
                        finalValue *= 1 + sumPercent;
                        sumPercent = 0;
                    }
                }
            }

            return (float)Math.Round(finalValue, 4);
        }

        public virtual void updateBaseValue()
        {
            isDirty = true;
            BaseValue = this.Value;
        }
    }
}
