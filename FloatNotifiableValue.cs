using System;

namespace VodByte.NotifiableValues
{
    public class FloatNotifiableValue : INotifyValueChanged<float>
    {
        public override bool Equals(object obj) => obj is FloatNotifiableValue value && Equals(value);
        public bool Equals(FloatNotifiableValue other) => _value == other._value;
        public override int GetHashCode() => Value.GetHashCode();
        public static bool operator ==(FloatNotifiableValue left, FloatNotifiableValue right) => left.Equals(right);
        public static bool operator !=(FloatNotifiableValue left, FloatNotifiableValue right) => !(left == right);
        public static implicit operator float(FloatNotifiableValue _notifyInt) => _notifyInt.Value;

        ///=============================================
        /// ███████╗██╗   ██╗███████╗███╗   ██╗████████╗
        /// ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝
        /// █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   
        /// ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   
        /// ███████╗ ╚████╔╝ ███████╗██║ ╚████║   ██║   
        /// ╚══════╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   
        ///=============================================
        /// <summary> 监听数据变化：第一个参数是旧值，第二个是新值 </summary>
        public event Action<float, float> OnValueChanged;

        ///===================================
        ///  ██████╗████████╗ ██████╗ ██████╗ 
        /// ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗
        /// ██║        ██║   ██║   ██║██████╔╝
        /// ██║        ██║   ██║   ██║██╔══██╗
        /// ╚██████╗   ██║   ╚██████╔╝██║  ██║
        ///  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
        ///===================================
        public FloatNotifiableValue(float _defautValue = default)
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
        float _value;
        public float Value
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

        ///---------------------------------------------------------------
        ///<summary> 不触发数值变化事件下改变数值 </summary>
        public void SetValueWithoutNotify(float _newVal) => _value = _newVal;
    }
}