using System;

namespace VodByte.NotifiableValues
{
    public class ReferenceNotifiableValue<T> : INotifyValueChanged<T>, IEquatable<ReferenceNotifiableValue<T>> where T : class
    {
        public static bool operator ==(ReferenceNotifiableValue<T> left, ReferenceNotifiableValue<T> right)
        {
            return left.Value.Equals(right.Value);
        }

        public static bool operator !=(ReferenceNotifiableValue<T> left, ReferenceNotifiableValue<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj) => obj is ReferenceNotifiableValue<T> value && Equals(value);
        public bool Equals(ReferenceNotifiableValue<T> other) => Equals(_value, other._value);
        public override int GetHashCode() => _value.GetHashCode();
        public static implicit operator T(ReferenceNotifiableValue<T> _value) => _value.Value;

        ///=============================================
        /// ███████╗██╗   ██╗███████╗███╗   ██╗████████╗
        /// ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝
        /// █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   
        /// ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   
        /// ███████╗ ╚████╔╝ ███████╗██║ ╚████║   ██║   
        /// ╚══════╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   
        ///=============================================
        /// <summary> 监听数据变化：第一个参数是旧值，第二个是新值 </summary>
        public event Action<T, T> OnValueChanged;

        ///======================================================================
        /// ██████╗ ██████╗  ██████╗ ██████╗ ███████╗██████╗ ████████╗██╗███████╗
        /// ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██║██╔════╝
        /// ██████╔╝██████╔╝██║   ██║██████╔╝█████╗  ██████╔╝   ██║   ██║█████╗  
        /// ██╔═══╝ ██╔══██╗██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗   ██║   ██║██╔══╝  
        /// ██║     ██║  ██║╚██████╔╝██║     ███████╗██║  ██║   ██║   ██║███████╗
        /// ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚══════╝
        ///======================================================================
        T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                var oldVal = _value;
                _value = value;
                OnValueChanged?.Invoke(oldVal, _value);
            }
        }

        ///=============================================
        ///  ██████╗ ██╗   ██╗████████╗███████╗██████╗ 
        /// ██╔═══██╗██║   ██║╚══██╔══╝██╔════╝██╔══██╗
        /// ██║   ██║██║   ██║   ██║   █████╗  ██████╔╝
        /// ██║   ██║██║   ██║   ██║   ██╔══╝  ██╔══██╗
        /// ╚██████╔╝╚██████╔╝   ██║   ███████╗██║  ██║
        ///  ╚═════╝  ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝
        ///=============================================
        public void ClearAllListener() => OnValueChanged = null;

        ///---------------------------------------------------------------
        public void SetValueWithoutNotify(T _newVal) => _value = _newVal;
    }
}