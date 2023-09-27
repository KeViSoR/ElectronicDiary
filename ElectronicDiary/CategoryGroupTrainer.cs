using ElectronicDiary.Entity;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary
{
    internal class CategoryGroupTrainer
    {
        
        public Stage? StageGroup { get; private set; }
        public List<GroupCountPerson> GroupCountPer { get; private set; }
        public CategoryGroupTrainer(Stage stage, int trainerId, List<Group> groupList, List<SportsmensGroup> listSportsmensGroup)
        {
            UpdateCategoryGroup(stage, trainerId, groupList, listSportsmensGroup);
        }
        public void UpdateCategoryGroup(Stage stage, int trainerId,List<Group> groupList, List<SportsmensGroup> listSportsmensGroup)
        {
            StageGroup = stage;
            if (groupList is null) return;
            List<Group>? _groupList = groupList.Where(g=> g.TrainerId== trainerId && g.StageId == stage.Id).ToList();
            if (_groupList is null) return;
            GroupCountPer = new List<GroupCountPerson>();
            foreach(var sGroup in _groupList)
            {
                GroupCountPer.Add(new GroupCountPerson(sGroup, listSportsmensGroup));
            }
        }
    }
    internal class GroupCountPerson
    {
        public Group TGroup { get; private set; }
        public int CountPerson { get; private set; }
        public GroupCountPerson(Group group, List<SportsmensGroup> listSportsmensGroup)
        {
            UpdateGroup(group, listSportsmensGroup);
        }
        public void UpdateGroup(Group group, List<SportsmensGroup> listSportsmensGroup)
        {
            TGroup = group;
            CountPerson = listSportsmensGroup.Where(g=>g.GroupId==group.Id).Count();
        }
    }
}
