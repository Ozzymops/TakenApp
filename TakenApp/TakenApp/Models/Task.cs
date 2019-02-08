using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace TakenApp.Models
{
    [Table("Task")]
    public class Task
    {
        [PrimaryKey, NotNull, AutoIncrement]public int Id { get; set; }
        [NotNull]public string Name { get; set; }
        public string Description { get; set; }

        [NotNull]public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Wanneer herhaalt de taak zich? Geteld in dagen.
        /// </summary>
        public int Interval { get; set; }

        // Status
        public bool Finished { get; set; }
        public bool Late { get; set; }
    }
}
