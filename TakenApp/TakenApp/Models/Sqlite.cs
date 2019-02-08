using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using Xamarin.Forms;

using TakenApp.Interfaces;

namespace TakenApp.Models
{
    public class Sqlite
    {
        private Logger logger = new Logger();
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Models.Task> Tasks { get; set; }

        public Sqlite()
        {
            database = DependencyService.Get<iSql>().DbConnection();
            database.CreateTable<Models.Task>();
            this.Tasks = new ObservableCollection<Models.Task>(database.Table<Models.Task>());
        }

        /// <summary>
        /// Debug functie: reset de database tables. Plaats in consturctor ná de DbConnection
        /// </summary>
        public void ResetDatabase()
        {
            database.DropTable<Models.Task>();
        }

        /// <summary>
        /// Voeg een taak toe. Keer een boolean terug als status
        /// </summary>
        /// <param name="task"></param>
        /// <returns>Status bool</returns>
        public bool AddTask(Models.Task task)
        {
            try
            {
                if (task != null)
                {
                    database.Insert(task);
                    logger.WriteToLog("AddTask succes", "Task is opgeslagen.");
                    return true;
                }
                else
                {
                    logger.WriteToLog("AddTask failure", "Task is null.");
                    return false;
                }               
            }
            catch (Exception e)
            {
                logger.WriteToLog("AddTask exception", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Verwijder een taak. Keer een boolean terug als status
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Status bool</returns>
        public bool RemoveTask(Models.Task task)
        {
            try
            {
                if (task.Id > 0)
                {
                    database.Delete<Models.Task>(task.Id);
                    logger.WriteToLog("RemoveTask succes", "Task " + task.Id + " is verwijderd.");
                    return true;
                }
                else
                {
                    logger.WriteToLog("RemoveTask failure", "Id is less or equal than zero.");
                    return false;
                }                
            }
            catch (Exception e)
            {
                logger.WriteToLog("RemoveTask exception", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Haal een lijst van taken op. Keer een lijst terug van taken
        /// </summary>
        /// <returns>Task list</returns>
        public List<Models.Task> GetTasks()
        {
            try
            {
                List<Models.Task> taskList = new List<Models.Task>();
                taskList = database.Query<Models.Task>("SELECT * FROM Task");

                logger.WriteToLog("GetTasks succes", "Tasks zijn opgehaald.");
                return taskList;
            }
            catch (Exception e)
            {
                logger.WriteToLog("GetTasks exception", e.ToString());
                return null;
            }
        }
    }
}
