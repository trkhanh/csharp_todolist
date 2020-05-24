namespace ToDoList.Models
{
    using System;

    /// <summary>
    /// Combine Urgency and Importance using Flags
    /// <para>Order is important for sorting by priority.</para>>
    /// </summary>
    [Flags]
    public enum Priority
    {
        /// <summary>
        /// There is no priority set
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Priority is set to urgent
        /// </summary>
        Urgent = 0x1,

        /// <summary>
        /// Priority is set to important
        /// </summary>
        Important = 0x2
    }
}
