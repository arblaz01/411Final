using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CIS411Final.Models;

namespace CIS411Final.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private ApplicationDbContext _db;

        public ApplicationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        //Groups
        public IQueryable<Group> GetAllGroupsAndMembers()
        {
            return _db.Groups;
        }

        public Group GetGroupById(int groupId)
        {
            return _db.Groups.Find(groupId);
        }

        public void AddStudentToGroup(int groupId, ApplicationUser user)
        {
            _db.Groups.Find(groupId).Students.Add(user);
            
        }

        public void AddGroup(Group group)
        {
            _db.Groups.Add(group);
        }
       //Users
        public ApplicationUser GetUser(string userId)
        {
            return _db.Users.Find(userId);
        }

        public void SaveAll()
        {
            _db.SaveChanges();
        }

    }
}