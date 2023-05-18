using System;

namespace VodByte.NotifiableValues
{
    public class BoolNotifiableValue : INotifyValueChanged<bool>
    {
        public override bool Equals(object obj) => obj is BoolNotifiableValue value && Equals(value);
        public bool Equals(BoolNotifiableValue other) => _value == other._value;
        public override int GetHashCode() => Value.GetHashCode();
        public static bool operator ==(BoolNotifiableValue left, BoolNotifiableValue right) => left.Equals(right);
        public static bool operator !=(BoolNotifiableValue left, BoolNotifiableValue right) => !(left == right);
        public static implicit operator bool(BoolNotifiableValue _notifyInt) => _notifyInt.Value;

        ///=============================================
        /// ███████╗██╗   ██╗███████╗███╗   ██╗████████╗
        /// ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝
        /// █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   
        /// ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   
        /// ███████╗ ╚████╔╝ ███████╗██║ ╚████║   ██║   
        /// ╚══════╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   
        ///=============================================
        /// <summary> 监听数据变化：第一个参数是旧值，第二个是新值 </summary>
        public event Action<bool, bool> OnValueChanged;

        ///===================================
        ///  ██████╗████████╗ ██████╗ ██████╗ 
        /// ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗
        /// ██║        ██║   ██║   ██║██████╔╝
        /// ██║        ██║   ██║   ██║██╔══██╗
        /// ╚██████╗   ██║   ╚██████╔╝██║  ██║
        ///  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
        ///===================================
        public BoolNotifiableValue(bool _defautValue)
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
        bool _value;
        public bool Value
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
        public void SetValueWithoutNotify(bool _newVal) => _value = _newVal;
    }
}