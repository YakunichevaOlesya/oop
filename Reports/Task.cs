using System;
using System.Collections.Generic;
using Task6_Report.Tests;

namespace Task6_Report
{
    public abstract class Task
    {
        public readonly int ID;
        public readonly string Name;

        private Worker owner;
        public Worker Owner
        {
            set
            {
                if (State == "Resolved")
                    throw new ReportException("Sorry, Task is Resolved");
                else
                {
                    owner = value;
                }

            }
            get => owner;
        }

        public DateTime CreationDate { get; protected set; }
        public DateTime ChangeDate { get; protected set; }

        public string State { get; protected set; } = "Open"; // Open, Active, Resolved
        List<Comment> Comments = new List<Comment>();
        public void NewComment(Worker worker, string comment)
        {
            Comments.Add(new Comment(worker, comment));
            ChangeDate = DateTime.Now;
        }
        public bool DoWork(Worker worker)
        {
            if (worker != owner || State == "Resolved")
                return false;
            State = "Active";
            Work();
            ChangeDate = DateTime.Now;
            NewComment(owner, "Done Some Work");
            return true;
        }
        public abstract void Work();

        public Task(int id, string name)
        {
            ID = id;
            Name = name;
            CreationDate = DateTime.Now;
            ChangeDate = DateTime.Now;
        }

        public void Finish()
        {
            ChangeDate = DateTime.Now;
            State = "Resolved";
        }

        public bool DoesHeWorked(Worker worker)
        {
            return Comments.Exists(item => item.Author == worker);
        }

    }


    public class ConcreteTask : Task
    {
        public override void Work()
        {
            Console.WriteLine("");
        }

        public ConcreteTask(int id, string name):
            base(id, name)
        { }
    } 
}
