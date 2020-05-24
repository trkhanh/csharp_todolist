namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// Long term task which can contain subtasks and has a deadline
    /// </summary>
    public class Goal : Task, IComparable<Goal>, IDateable
    {
        /// <summary>
        /// The time set for accomplishing the goal
        /// </summary>
        private DateTime deadline;

        /// <summary>
        /// The collection of subtasks for this goal
        /// </summary>
        private ObservableCollection<Goal> subtasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Goal"/> class
        /// <para>Long term task which can contain subtasks and has a deadline</para>
        /// </summary>
        public Goal()
        {
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.EventDate = DateTime.Today;
            this.subtasks = new ObservableCollection<Goal>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goal"/> class
        /// <para>Long term task which can contain subtasks and has a deadline</para>
        /// </summary>
        /// <param name="title">The goal's title</param>
        /// <param name="description">The goal's description</param>
        /// <param name="deadline">The time by which the goal should be achieved</param>
        /// <param name="priority">The goal's priority</param>
        public Goal(string title, string description, DateTime deadLine, Priority priority = Priority.None)
            : base(title, description, priority)
        {
            this.EventDate = deadLine;
            this.subtasks = new ObservableCollection<Goal>();
        }

        /// <summary>
        /// Gets or sets the time set for accomplishing the goal
        /// </summary>
        public DateTime EventDate
        {
            get
            {
                return this.deadline.Date;
            }

            set
            {
                this.deadline = value;
                this.OnPropertyChanged("EventDate");
            }
        }

        /// <summary>
        /// Gets or sets a collection of subtasks for this goal
        /// </summary>
        /// <exception cref="NullReferenceException">Trying to assign null value to the goal's collection of the subtasks</exception>
        public ObservableCollection<Goal> Subtasks
        {
            get
            {
                return this.subtasks;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(
                        string.Format("Trying to assign null value to Subtasks collection of the goal [{0}]", this.Title));
                }

                this.subtasks = value;
            }
        }

        /// <summary>
        /// Add a subtask to the goal
        /// </summary>
        /// <param name="subtask">Subtask to be added to the goal</param>
        public void AddSubtask(Goal subtask)
        {
            this.subtasks.Add(subtask);
        }

        /// <summary>
        /// Remove a subtask from the goal
        /// </summary>
        /// <param name="subtask">Subtask to be removed from the goal</param>
        public void RemoveSubtask(Goal subtask)
        {
            if (this.subtasks.Contains(subtask))
            {
                this.subtasks.Remove(subtask);
            }
        }

        /// <summary>
        /// A method for editing the goal's end date.
        /// </summary>
        /// <param name="months">The number of months to be added to the end date for this goal</param>
        public void ExtendDuration(int months)
        {
            this.EventDate = this.EventDate.AddMonths(months);
        }

        /// <summary>
        /// Compares this instance with a specific ToDoList.Models.Goal and indicates whether this instance precedes, follows,
        /// or appears in the same position in the sort order as the specified ToDoList.Models.Goal
        /// </summary>
        /// <param name="other">A ToDoList.Models.Goal to compare this instance to</param>
        /// <returns>-1, 0, or 1 depending on the end dates of the goals that are compared</returns>
        public int CompareTo(Goal other)
        {
            return this.EventDate.CompareTo(other.EventDate);
        }

        /// <summary>
        /// Returns all the information of this instance of <see cref="Goal"/> as a string
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}\n{1}\n", base.ToString(), this.EventDate);

            foreach (Task subtask in this.Subtasks)
            {
                output.AppendLine(subtask.ToString());
            }

            return output.ToString();
        }
    }
}
