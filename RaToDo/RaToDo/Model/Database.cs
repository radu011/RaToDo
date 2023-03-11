using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RaToDo.Model
{
    public class Database
    {
        readonly ABDEntities context = new ABDEntities();

        public bool VerifyUserForLogin(string username, string password)
        {
            var results = from u in context.Utilizatoris
                          where u.Username == username
                          select u;

            if (results.Count() > 1)
            {
                throw new Exception("Database error!\n");
            }

            if (password != results.First().Pass)
                return false;

            return true;
        }

        public bool VerifyUserForRegister(string username)
        {
            var results = from u in context.Utilizatoris
                          where u.Username == username
                          select u;

            if (results.Count() != 0)
                return false;

            return true;
        }

        public bool RegisterUser(int IdTipUtilizator, string name, string secondName, string username, string password, string email)
        {
            var newUser = new Utilizatori(IdTipUtilizator, name, secondName, username, password, email);

            context.Utilizatoris.Add(newUser);
            context.SaveChanges();

            return true;
        }

        public bool VerifyPasswordReset(string username, string email)
        {
            var results = from u in context.Utilizatoris
                          where u.Username == username && u.E_mail == email
                          select u;

            if (results.Count() == 0)
                return false;

            return true;
        }

        // add task to database
        public bool AddTask(int IdTipTask, int IdCategorie, int IdUtilizator, string Titlu, string Descriere, DateTime Deadline, bool Stare, bool Remainder)
        {
            var resultsTipTask = from tt in context.Tip_Task
                                 where tt.IDTipTask == IdTipTask
                                 select tt;
            if (resultsTipTask.Count() == 0)
                return false;

            var resultsCategorie = from c in context.Categoriis
                                   where c.IDCategorie == IdCategorie && c.IDUtilizator == IdUtilizator
                                   select c;
            if (resultsCategorie.Count() == 0)
                return false;

            var resultsUtilizator = from u in context.Utilizatoris
                                    where u.IDUtilizator == IdUtilizator
                                    select u;
            if (resultsUtilizator.Count() == 0)
                return false;

            Task newTask = new Task(IdTipTask, IdCategorie, IdUtilizator, Titlu, Descriere, Deadline, Stare, Remainder);
            context.Tasks.Add(newTask);
            context.SaveChanges();

            return true;
        }
        public bool AddTask(string NumeTipTask, string NumeCategorie, string NumeUtilizator, string Titlu, string Descriere, DateTime Deadline, bool Stare, bool Remainder)
        {
            int IdTipTask = (from tt in context.Tip_Task
                             where tt.Denumire == NumeTipTask
                             select tt.IDTipTask).First();

            int IdUtilizator = (from u in context.Utilizatoris
                                where u.Username == NumeUtilizator
                                select u.IDUtilizator).First();

            int IdCategorie;
            var res = from c in context.Categoriis
                      where c.Nume == NumeCategorie
                      select c.IDCategorie;
            if (res.Count() == 0)
            {
                AddCategory(IdUtilizator, NumeCategorie);
                IdCategorie = getCategoryIdByCategoryName(NumeCategorie);
            }
            else
                IdCategorie = res.First();

            return AddTask(IdTipTask, IdCategorie, IdUtilizator, Titlu, Descriere, Deadline, Stare, Remainder);
        }

        // delete task from database
        public bool DeleteTask(int _IDTaks)
        {
            var task = (from t in context.Tasks
                        where t.IDTask == _IDTaks
                        select t).First();

            context.Tasks.Remove(task);
            context.SaveChanges();

            return true;
        }

        // modify task from database
        public bool UpdateTask(int _IDTaks, DateTime _data, string _titlu, string _descriere, string _category, bool _isDone)
        {
            var task = (from t in context.Tasks
                        where t.IDTask == _IDTaks
                        select t).First();

            task.Deadline = _data;
            task.Titlu = _titlu;
            task.Descriere = _descriere;
            task.Stare = _isDone;

            var idCategory = (from c in context.Categoriis
                              where _category == c.Nume
                              select c.IDCategorie);

            if (idCategory.Count() != 1)
            {
                return false;
            }
            task.IDCategorie = idCategory.First();

            context.SaveChanges();

            return true;
        }

        // add category to database
        public bool AddCategory(int _idUtilizator, string numeCategorie)
        {
            Categorii categorieNoua = new Categorii(_idUtilizator, numeCategorie);

            context.Categoriis.Add(categorieNoua);
            context.SaveChanges();

            return true;
        }
        public bool AddCategory(string _username, string numeCategorie)
        {
            int _idUtilizator = (from u in context.Utilizatoris
                                 where u.Username == _username
                                 select u.IDUtilizator).First();

            return AddCategory(_idUtilizator, numeCategorie);
        }

        // get categories by username
        public List<string> getCategories(string _username)
        {
            var list = new List<string>();

            var userId = (from u in context.Utilizatoris
                          where u.Username == _username
                          select u.IDUtilizator).First();

            var results = from c in context.Categoriis
                          where c.IDUtilizator == userId
                          select c.Nume;

            foreach (var res in results)
            {
                list.Add(res.ToString());
            }

            return list;
        }

        public bool deleteCategory(string _username, string _catName)
        {

            var userId = (from u in context.Utilizatoris
                          where u.Username == _username
                          select u.IDUtilizator).First();

            var results = (from c in context.Categoriis
                           where c.IDUtilizator == userId && c.Nume == _catName
                           select c).FirstOrDefault();

            var tasks = (from t in context.Tasks
                         where results.IDCategorie == t.IDCategorie
                         select t).ToList();
            if (tasks.Count > 0)
                return false;

            context.Categoriis.Remove(results);
            context.SaveChanges();

            return true;
        }

        // get tasks by username
        public IQueryable<Task> getTasks(string _username)
        {
            var userId = (from u in context.Utilizatoris
                          where u.Username == _username
                          select u.IDUtilizator).FirstOrDefault();

            var results = from t in context.Tasks
                          where t.IDUtilizator == userId
                          select t;

            return results;
        }

        // get task category
        public string getTaskCategory(int taskId)
        {
            var strCategory = from c in context.Categoriis
                              where c.IDCategorie == (from t in context.Tasks
                                                      where taskId == t.IDTask
                                                      select t.IDCategorie).FirstOrDefault()
                              select c.Nume.ToString();

            return strCategory.FirstOrDefault().ToString();
        }

        // get type of task
        public string getTypeOfTask(int taskId)
        {
            var type = from tt in context.Tip_Task
                       where tt.IDTipTask == (from t in context.Tasks
                                              where t.IDTask == taskId
                                              select t.IDTipTask).FirstOrDefault()
                       select tt.Denumire;

            return type.FirstOrDefault().ToString();
        }

        // get user ID by task id
        public int getUserIDbyTaskID(int taskId)
        {
            var res = (from t in context.Tasks
                       where t.IDTask == taskId
                       select t.IDUtilizator).First();

            return res;
        }

        // get types of tasks
        public List<string> getTypes()
        {
            List<string> list = new List<string>();

            var results = from t in context.Tip_Task
                          select t.Denumire;

            foreach (var res in results)
                list.Add(res);

            return list;
        }


        // get task type id by name
        public int getTaskTypeByTypeName(string name)
        {
            return (from t in context.Tip_Task
                    where t.Denumire == name
                    select t.IDTipTask).First();
        }

        // get category id by name
        public int getCategoryIdByCategoryName(string categoryName)
        {
            return (from c in context.Categoriis
                    where c.Nume == categoryName
                    select c.IDCategorie).First();
        }

        public void changeRemainder(string _username, bool remainder)
        {
            var tasks = from t in context.Tasks
                        where t.IDUtilizator == (from u in context.Utilizatoris
                                                 where u.Username == _username
                                                 select u.IDUtilizator).FirstOrDefault()
                        select t;
            foreach (var task in tasks)
            {
                task.Remainder = remainder;
            }
            context.SaveChanges();
        }
    }
}
