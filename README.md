# NotifiableValues
When the basic type value changes, the wrapper class that notifies the listener. 
When making games, many UI and gameplay logics need to pay attention to the player's attribute values. 
This wrapper class can make it more convenient to use the observer pattern.

## Usages
```c sharp
public readonly FloatNotifiableValue HealthPoint = new(10f);

HealthPoint.OnValueChanged += (_oldVal, _newVal) =>
{
	Debug.Log($"HP -{_newVal - _oldVal}");
}

// Should logout "HP -2"
HealthPoint.Value -= 2f;
```