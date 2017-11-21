using Lab9.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Lab9.BusinessLayer.Interfaces
{
    public interface IGroupService
    {
        ObservableCollection<GroupViewModel> GetAll();
        GroupViewModel Get(int id);
        void AddStudentToGroup(int droupId, StudentViewModel student);
        void RemoveStudentFromGroup(int droupId, int studenIdt);
        void CreateGroup(GroupViewModel group);
        void DeleteGroup(int groupId);
        void UpdateGroup(GroupViewModel group);
    }
}
