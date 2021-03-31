using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Project_One
{
    class ProjectOne_Menu_Repository
    {
        protected readonly List<ProjectOne_Menu_Class> _MenuRepo = new List<ProjectOne_Menu_Class>();

        //Create
        public bool AddMenuItem(ProjectOne_Menu_Class MenuRepo)
        {
            int starting = _MenuRepo.Count;
            _MenuRepo.Add(MenuRepo);
            bool Confirm = (_MenuRepo.Count > starting) ? true : false;
            return Confirm;
        }
        //Read
        public List<ProjectOne_Menu_Class> ReadMenu()
        {
            return _MenuRepo;
        }        
        //Delete
        public bool DeleteMenuItem(ProjectOne_Menu_Class desired)
        {
            bool killed = _MenuRepo.Remove(desired);
            return killed;
        }
    }
}
