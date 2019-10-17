using System;
using System.Collections.Generic;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{


    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group Editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal List<GroupData> GetGroupList()
        {
            return new List<GroupData>();
        }

        internal void Add(GroupData newGroup)
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            
        }
    }
}