using System;

namespace VodByte.NotifiableValues
{
    public class IntNotifiableValue : INotifyValueChanged<int>, IEquatable<IntNotifiableValue>
    {
        public override bool Equals(object obj) => obj is IntNotifiableValue value && Equals(value);
        public bool Equals(IntNotifiableValue other) => _value == other._value;

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(IntNotifiableValue left, IntNotifiableValue right) => left.Equals(right);
        public static bool operator !=(IntNotifiableValue left, IntNotifiableValue right) => !(left == right);

        public static implicit operator int(IntNotifiableValue _notifyInt) => _notifyInt.Value;

        ///=============================================
        /// ███████╗██╗   ██╗███████╗███╗   ██╗████████╗
        /// ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝
        /// █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   
        /// ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   
        /// ███████╗ ╚████╔╝ ███████╗██║ ╚████║   ██║   
        /// ╚══════╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   
        ///=============================================
        /// <summary> 监听数据变化：第一个参数是旧值，第二个是新值 </summary>
        public event Action<int, int> OnValueChanged;

        ///===================================
        ///  ██████╗████████╗ ██████╗ ██████╗ 
        /// ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗
        /// ██║        ██║   ██║   ██║██████╔╝
        /// ██║        ██║   ██║   ██║██╔══██╗
        /// ╚██████╗   ██║   ╚██████╔╝██║  ██║
        ///  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
        ///===================================
        public IntNotifiableValue(int _defautValue = default)
        {
            _value = _defautValue;
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
        int _value;
        public int Value
        {
            get => _value;
            set
            {
                // 两值相等：直接回退
                if (_value == value) return;
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

        ///<summary> 不触发数值变化事件下改变数值 </summary>
        public void SetValueWithoutNotify(int _newVal) => _value = _newVal;
    }
}