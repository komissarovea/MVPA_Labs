using System;
using System.Collections.ObjectModel;
using Lab9.BusinessLayer.Interfaces;
using Lab9.DataLayer.Entities;
using Lab9.BusinessLayer.Models;
using Lab9.DataLayer.Interfaces;
using Lab9.DataLayer.Repositories;
using AutoMapper;

namespace Lab9.BusinessLayer.Services
{
    public class GroupService : IGroupService
    {
        IUnitOfWork dataBase;
        public GroupService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
            // Конфигурировани AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Group, GroupViewModel>();
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<StudentViewModel, Student>();
            });
        }

        public void AddStudentToGroup(int droupId, StudentViewModel student)
        {
            var group = dataBase.Groups.Get(droupId);
            // Отображение объекта StudentViewModel на объект Student
            var stud = Mapper.Map<Student>(student);
            // Определение цены для студента
            stud.IndividualPrice = student.HasDiscount == true
                ? group.BasePrice * (decimal)0.8
                : group.BasePrice;
            // Добавить студента
            group.Students.Add(stud);
            // Сохранить изменения
            dataBase.Save();
        }

        public void CreateGroup(GroupViewModel group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public GroupViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<GroupViewModel> GetAll()
        {
          
            // Отображение List<Group> на
            ObservableCollection<GroupViewModel> groups =  
                Mapper.Map<ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            return groups;
        }

        public void RemoveStudentFromGroup(int droupId, int studenIdt)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupViewModel group)
        {
            throw new NotImplementedException();
        }
    }
}