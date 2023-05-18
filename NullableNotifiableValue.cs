using System;

namespace VodByte.NotifiableValues
{
    public class NullableNotifiableValue<T> where T : struct
    {
        public event Action<T?, T?> OnValueChanged;

        T? m_value;
        public T? Value
        {
            get => m_value;
            set
            {
                if (IsValueEqual(m_value, value)) return;
                var oldVal = m_value;
                m_value = value;
                OnValueChanged?.Invoke(oldVal, m_value);
            }
        }

        public void ClearAllListener() => OnValueChanged = null;
        public bool IsValueEqual(T? _a, T? _b) => Nullable.Equals(_a, _b);
        public void SetValueWithoutNotify(T? _newVal) => m_value = _newVal;
    }
}