using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using CIS411Final.Data;
using CIS411Final.Models;
using Microsoft.AspNet.Identity;

namespace CIS411Final.Controllers
{
    public class GroupController : Controller
    {
        private IApplicationRepository _repo;

        //GetGroupById(int groupId)  --> single group based on PK
        //GetAllGroupsAndMembers()   --> all groups and their members
        //AddStudentToGroup()        --> adds logged in student to specified group
        //AddStudentToGroup(int groupId, ApplicationUser user)   --> Adds logged in student to group
        //AddGroup(Group group)      --> Adds a group to the database
        //GetUser()                  --> Gets the current logged in user
        //SaveAll()                  --> Saves changes to the DB

        public GroupController(IApplicationRepository repo)
        {
            _repo = repo;
        }

        
        public ActionResult Index()
        {
            var groupList = _repo.GetAllGroupsAndMembers();
            
            return View(groupList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Group group)
        {
            try
            {
                _repo.AddGroup(group);
                _repo.SaveAll();
            }
            catch (Exception)
            {
                //TODO Add user feedback if error
                throw;
            }
            return RedirectToAction("Index");

        }

        public ActionResult JoinGroup(int id)
        {
            var group = _repo.GetGroupById(id);

            return View(group);
        }
        [HttpPost]
        public ActionResult JoinGroup(Group group)
        {
            var user = _repo.GetUser(User.Identity.GetUserId());
            try
            {
                _repo.AddStudentToGroup(group.GroupId, user);
                _repo.SaveAll();
            }
            catch (Exception)
            {
                //TODO Supply user feedback
                throw;
            }
            

            return RedirectToAction("Index");
        }

        
    }
}
