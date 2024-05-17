using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Practice
{
    // СПИСОК ТИПА РОЛЬ-РАЗРЕШЕНИЕ
    // РАЗРЕШЕНИЯ ОПРЕДЕЛЯЮТ ТО, КАИКЕ КНОПКИ ВИДИТ ПОЛЬЗОВАТЕЛЬ => КАКИЕ ДЕЙСТВИЯ ОН МОЖЕТ СОВЕРШАТЬ
    public class Rules
    {
        string role;
        
        // (1) таблицы только для просмотра
        public bool AVGStudentScoresTableSee = false;
        public bool LeaveStudentsTableSee = false;
        public bool StudentsTableSee = false;
        public bool TeachersTableSee = false;
        // (2) таблицы, которые можно редактировать и просматривать
        public bool DisciplinesTableSee = false;
        public bool DisciplinesTableEdit = false;
        public bool GradesTableSee = false;
        public bool GradesTableEdit = false;
        public bool GroupsTableSee = false;
        public bool GroupsTableEdit = false;
        public bool RUPTableSee = false;
        public bool RUPTableEdit = false;
        public bool SpecialitiesTableSee = false;
        public bool SpecialitiesTableEdit = false;

        // метод для тех, кто видит все таблицы
        public void ISEEALL() 
        {
            AVGStudentScoresTableSee = true;
            LeaveStudentsTableSee = true;
            StudentsTableSee = true;
            TeachersTableSee = true;
            DisciplinesTableSee = true;
            GradesTableSee = true;
            GroupsTableSee = true;
            RUPTableSee = true;
            SpecialitiesTableSee = true;
        }


        public Rules(string role) {
            this.role = role;
            
            if(role == "Teacher")
            {
                ISEEALL();
                GradesTableEdit = true;
            }
            else if (role == "Curator")
            {
                StudentsTableSee = true;
                GradesTableSee = true;
            }
            else if (role == "Dispetcher")
            {
                DisciplinesTableSee=true;
                SpecialitiesTableSee=true;
                TeachersTableSee=true;
                GradesTableSee=true;
                GroupsTableSee=true;
                RUPTableSee=true;
            }
            else if (role == "ZavedUchebki")
            {
                ISEEALL();
                DisciplinesTableEdit = true;
                SpecialitiesTableEdit = true;
                GroupsTableEdit = true;
                RUPTableEdit = true;
            }
            else if (role == "Student")
            {
                GradesTableSee = true;
            }
        }
    }
}
