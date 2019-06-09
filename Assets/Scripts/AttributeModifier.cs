
public enum AttributeModType
{
    Flat,
    Percent,
}

public class AttributeModifier
{
	public readonly float Value;
	public readonly AttributeModType Type;
	public readonly int Order;
	public readonly object Source;

	
	public AttributeModifier(float value, AttributeModType type, int order, object source)
	{
		Value = value;
		Type = type;
		Order = order;
		Source = source;
	}
	 
	public AttributeModifier(float value, AttributeModType type, object source) : this(value, type, (int)type, source) { }
}