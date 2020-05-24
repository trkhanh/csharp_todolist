// namespace ToDoList.Models
// {
//     using System;
//     using System.Linq;
//     using System.Xml.Linq;
//     using System.Reflection;
//     using System.Collections.Generic;
//     /// <summary>
//     /// Serves to process all reading and writing of tasks to an XML file
//     /// </summary>
//     public class DataManager
//     {
//         /// <summary>
//         /// Get all tasks from an XML database
//         /// </summary>
//         /// <param name="pathToTasks">Path of the XML database</param>
//         public static IEnumerable<Task> GetTasks(string pathToTasks)
//         {
//             var tasksRoot = XDocument.Load(pathToTasks).Root;
//             var tasks = from task in tasksRoot.Elements("task")
//                         select new Task()
//                         {
//                             Title = task.Element("title").Value,
//                             Description = task.Element("description").Value,
//                             Priority = (Priority)int.Parse(task.Element("priority").Value),
//                             Tags = task.Elements("tags").Elements("tag").Select(t => t.Value)
//                         };
//             return tasks;
//         }
//         /// <summary>
//         /// Add a task to a XML database
//         /// </summary>
//         /// <param name="docPath">Path of the XML file</param>
//         /// <param name="task">Task to be added</param>
//         public static void AddTask(string docPath, Task task)
//         {
//             var root = XDocument.Load(docPath).Root;
//             var entry = new XElement("task",
//                 new XElement("title", task.Title),
//                 new XElement("description", task.Description),
//                 new XElement("priority", (int)task.Priority),
//                 new XElement("tags"));
//             foreach (var tag in task.Tags)
//             {
//                 entry.Element("tags").Add(new XElement("tag", tag));
//             }
//             root.Add(entry);
//             root.Document.Save(docPath);
//         }
//         public static void RemoveTask(Task target)
//         {
//         }
//         /// <summary>
//         /// Get all goals from an XML database
//         /// </summary>
//         /// <param name="pathToGoals">Path of the XML database</param>
//         public static IEnumerable<Goal> GetGoals(string pathToGoals)
//         {
//             var goalsRoot = XDocument.Load(pathToGoals).Root;
//             var goals = from goal in goalsRoot.Elements("goal")
//                         select new Goal()
//                         {
//                             Title = goal.Element("title").Value,
//                             Description = goal.Element("description").Value,
//                             Priority = (Priority)int.Parse(goal.Element("priority").Value),
//                             //Subtasks = (
//                             //                from task in goal.Elements("subtask")
//                             //                select new Task()
//                             //                {
//                             //                    Title = task.Element("title").Value,
//                             //                    Description = task.Element("description").Value,
//                             //                    Priority = (Priority)int.Parse(task.Element("priority").Value),
//                             //                    Tags = task.Elements("tags").Elements("tag").Select(t => t.Value),
//                             //                }
//                             //            ).ToList<Task>(),
//                             //EndDate = DateTime.Parse(goal.Element("enddate").Value),
//                             Tags = goal.Elements("tags").Elements("tag").Select(t => t.Value)
//                         };
//             return goals;
//         }
//         /// <summary>
//         /// Add a goal to a XML database
//         /// </summary>
//         /// <param name="docPath">Path of the XML file</param>
//         /// <param name="goal">Goal to be added</param>
//         public static void AddGoal(string docPath, Goal goal)
//         {
//             var root = XDocument.Load(docPath).Root;
//             var entry = new XElement("goal",
//                 new XElement("title", goal.Title),
//                 new XElement("description", goal.Description),
//                 new XElement("priority", (int)goal.Priority),
//                 new XElement("subtasks"),
//                 new XElement("datetime", string.Format("{0:yyyy, MM, dd}", goal.EndDate)),
//                 new XElement("tags"));
//             foreach (var subtask in goal.Subtasks)
//             {
//                 var subtaskEntry = new XElement("subtask",
//                     new XElement("title", subtask.Title),
//                     new XElement("description", subtask.Description),
//                     new XElement("priority", (int)subtask.Priority),
//                     new XElement("tags"));
//                 foreach (var tag in subtask.Tags)
//                 {
//                     subtaskEntry.Element("tags").Add(new XElement("tag", tag));
//                 }
//                 entry.Element("subtasks").Add(subtaskEntry);
//             }
//             foreach (var tag in goal.Tags)
//             {
//                 entry.Element("tags").Add(new XElement("tag", tag));
//             }
//             root.Add(entry);
//             root.Document.Save(docPath);
//         }
//     }
// }
