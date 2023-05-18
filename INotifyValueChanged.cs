using System;

namespace VodByte.NotifiableValues
{
    public interface INotifyValueChanged<T>
    {
        T Value { get; set; }

        /// <surrmay> 通知数值变化 </surrmay>
        /// <remarks> 第一个参数为旧值，第二个为新值 </remarks>
        event Action<T, T> OnValueChanged;

        ///<summary> 不触发数值变化事件下改变数值 </summary>
        void SetValueWithoutNotify(T _newVal);

        void ClearAllListener();
    }
}