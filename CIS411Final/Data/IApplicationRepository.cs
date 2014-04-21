using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS411Final.Models;

namespace CIS411Final.Data
{
    public interface IApplicationRepository
    {
        
        //Groups
        IQueryable<Group> GetAllGroupsAndMembers();
        Group GetGroupById(int groupId);
        void AddStudentToGroup(int groupId, ApplicationUser user);
        void AddGroup(Group group);
        //Users
        ApplicationUser GetUser(string userId);
        //Save
        void SaveAll();
        
    }
}
