using System;

namespace VodByte.NotifiableValues
{
    public class EnumNotifiValue<T> : INotifyValueChanged<T>, IEquatable<EnumNotifiValue<T>> where T : struct, Enum
    {
        public override bool Equals(object obj) => obj is EnumNotifiValue<T> value && Equals(value);
        public bool Equals(EnumNotifiValue<T> other) => Equals(_value, other._value);
        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(EnumNotifiValue<T> left, EnumNotifiValue<T> right) => left.Equals(right);
        public static bool operator !=(EnumNotifiValue<T> left, EnumNotifiValue<T> right) => !(left == right);

        public static implicit operator T(EnumNotifiValue<T> _value) => _value.Value;

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

        ///===================================
        ///  ██████╗████████╗ ██████╗ ██████╗ 
        /// ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗
        /// ██║        ██║   ██║   ██║██████╔╝
        /// ██║        ██║   ██║   ██║██╔══██╗
        /// ╚██████╗   ██║   ╚██████╔╝██║  ██║
        ///  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
        ///===================================
        public EnumNotifiValue(T _default = default)
        {
            _value = _default;
            OnValueChanged = null;
        }

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
                // 两值相等：直接回退
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