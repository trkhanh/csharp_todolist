namespace ToDoList.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents errors that occur during parsing data to specific format.
    /// </summary>
    [Serializable()]
    public class WrongFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrongFormatException"/> class
        /// </summary>
        public WrongFormatException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongFormatException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public WrongFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="WrongFormatException"/> class with a specified </para>
        /// <para>error message and a reference to the inner exception that is the cause of this exception.</para>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner"><para>The exception that is the cause of the current exception, or a null </para>
        /// <para>reference (Nothing in Visual Basic) if no inner exception is specified.</para></param>
        public WrongFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongFormatException"/> class with serialized data.
        /// </summary>
        /// <param name="info"><para>The System.Runtime.Serialization.SerializationInfo that holds </para>
        /// <para>the serialized object data about the exception being thrown.</para></param>
        /// <param name="context"><para>The System.Runtime.Serialization.StreamingContext that contains </para>
        /// <para>contextual information about the source or destination.</para></param>
        protected WrongFormatException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
