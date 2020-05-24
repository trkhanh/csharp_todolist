namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A reminder task that keeps birthday information
    /// </summary>
    public class BirthdayReminder : BaseObjectModel, IDateable
    {
        /// <summary>
        /// The name of the person who's birthday it is
        /// </summary>
        private string personName = null;

        // private byte age = 0;

        /// <summary>
        /// The date of birth of the person who's birthday it is
        /// </summary>
        private DateTime birthDate;

        /// <summary>
        /// The date of creation of this BirthdayReminder
        /// </summary>
        private DateTime dateCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayReminder"/> class
        /// <para>A reminder task that keeps birthday information</para>
        /// </summary>
        public BirthdayReminder()
        {
            this.PersonName = "Person's name";
            this.EventDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayReminder"/> class
        /// <para>A reminder task that keeps birthday information</para>
        /// </summary>
        /// <param name="personName">Name of the person who's birthday it is</param>
        /// <param name="description">The BirthdayReminder's description</param>
        /// <param name="birthDate">Date of birth of the person who's birthday it is</param>
        ///// <param name="title">The BirthdayReminder's title</param>
        ///// <param name="age">Age of the person who's birthday it is </param>
        // public BirthdayReminder(string title, string description, string personName, byte age, DateTime birthDate)
        public BirthdayReminder(string personName, string description, DateTime birthDate)
            : base(string.Empty, description)
        {
            this.DateCreated = DateTime.Now;
            this.PersonName = personName;
            this.EventDate = birthDate;

            // this.Age = age;
        }

        /// <summary>
        /// Gets or sets the name of the person who's birthday it is
        /// </summary>
        public string PersonName
        {
            get
            {
                return this.personName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("The age of the person must have name.");
                }

                this.personName = value;
                this.OnPropertyChanged("PersonName");
            }
        }

        /// <summary>
        /// Gets the age of the person who's birthday it is 
        /// </summary>
        public byte Age
        {
            get { return (byte)(DateTime.Now.Year - this.EventDate.Year); } // return this.age;
            // set
            // {
            //     if (value < 0)
            //     {
            //         throw new FormatException("The person must be on age bigger or equal to 0 years.");
            //     }
            //     this.age = value;
            // }
        }

        /// <summary>
        /// Gets or sets the date of birth of the person who's birthday it is
        /// </summary>
        public DateTime EventDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                this.OnPropertyChanged("EventDate");
                this.OnPropertyChanged("Age");
            }
        }

        /// <summary>
        /// Gets or sets the date of creation of this BirthdayReminder
        /// </summary>
        public DateTime DateCreated
        {
            get { return this.dateCreated; }
            set { this.dateCreated = value; }
        }
    }
}
