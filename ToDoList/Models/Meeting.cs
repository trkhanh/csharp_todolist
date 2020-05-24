namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using ToDoList.Exceptions;

    /// <summary>
    /// An object that keeps all the information about a meeting
    /// </summary>
    public class Meeting : BaseObjectModel, IComparable<Meeting>, IDateable
    {
        /// <summary>
        /// A regular expression representing the format for the meeting's starting time
        /// </summary>
        private const string StartTimeRegexMatch = @"^(([0-9])|([0-1][0-9])|([2][0-3])):([0-5][0-9])$";

        /// <summary>
        /// The meeting's date
        /// </summary>
        private DateTime beginning;

        /// <summary>
        /// The meeting's starting time
        /// </summary>
        private string startTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class
        /// <para>An object that keeps all the information about a meeting</para>
        /// </summary>
        public Meeting()
            : base()
        {
            this.Title = "New Meeting";
            this.Description = "Add Description";
            this.EventDate = DateTime.Now;
            this.StartTime = "hh:mm";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class
        /// <para>An object that keeps all the information about a meeting</para>
        /// </summary>
        /// <param name="title">The meeting's title</param>
        /// <param name="description">The meeting's description</param>
        /// <param name="startDate">The meeting's date</param>
        /// <param name="duration">The meeting's duration</param>
        /// <param name="startTime">The meeting's starting time</param>
        public Meeting(string title, string description, DateTime startDate, ushort duration, string startTime)
            : base(title, description)
        {
            this.EventDate = startDate;
            this.Duration = duration;
            this.StartTime = startTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class
        /// <para>An object that keeps all the information about a meeting</para>
        /// </summary>
        /// <param name="title">The meeting's title</param>
        /// <param name="description">The meeting's description</param>
        /// <param name="startDate">The meeting's date</param>
        /// <param name="startTime">The meeting's starting time</param>
        public Meeting(string title, string description, DateTime startDate, string startTime)
            : base(title, description)
        {
            this.EventDate = startDate;
            this.StartTime = startTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class
        /// <para>An object that keeps all the information about a meeting</para>
        /// </summary>
        /// <param name="title">The meeting's title</param>
        /// <param name="description">The meeting's description</param>
        /// <param name="startDate">The meeting's date</param>
        public Meeting(string title, string description, DateTime startDate)
            : base(title, description)
        {
            this.EventDate = startDate;
        }

        /// <summary>
        /// Gets or sets the meeting's duration
        /// </summary>
        public ushort Duration { get; set; }

        /// <summary>
        /// Gets or sets the meeting's starting time
        /// </summary>
        public string StartTime
        {
            get
            {
                return this.startTime;
            }

            set
            {
                this.startTime = value;

                try
                {
                    if (!Regex.IsMatch(this.startTime, StartTimeRegexMatch) && this.startTime != "hh:mm")
                    {
                        throw new WrongFormatException("Enter time in the format hh:mm e.g. 13:45");
                    }
                }
                catch(WrongFormatException)
                {
                    throw ;
                }
                
                this.OnPropertyChanged("StartTime");
            }
        }

        /// <summary>
        /// Gets or sets the meeting's date
        /// </summary>
        public DateTime EventDate
        {
            get
            {
                return this.beginning.Date;
            }

            set
            {
                this.beginning = value;
                this.OnPropertyChanged("EventDate");
            }
        }

        /// <summary>
        /// A method for editing this meeting's starting time
        /// </summary>
        /// <param name="newStartTime">The meeting's new starting time</param>
        public void EditStartTime(string newStartTime)
        {
            this.StartTime = newStartTime;
        }

        /// <summary>
        /// A method for editing this meeting's date
        /// </summary>
        /// <param name="newBeginning">The meeting's new date</param>
        public void EditBeginning(DateTime newBeginning)
        {
            this.EventDate = newBeginning;
        }

        /// <summary>
        /// A method for editing this meeting's duration
        /// </summary>
        /// <param name="newDuration">The meeting's new duration</param>
        public void EditDuration(ushort newDuration)
        {
            this.Duration = newDuration;
        }

        /// <summary>
        /// Compares this instance with a specific ToDoList.Models.Meeting and indicates whether this instance precedes, follows,
        /// or appears in the same position in the sort order as the specified ToDoList.Models.Meeting
        /// </summary>
        /// <param name="other">A ToDoList.Models.Meeting to compare this instance to</param>
        /// <returns>-1, 0, or 1 depending on the end dates of the goals that are compared</returns>
        public int CompareTo(Meeting other)
        {
            return this.EventDate.CompareTo(other.EventDate);
        }
    }
}
