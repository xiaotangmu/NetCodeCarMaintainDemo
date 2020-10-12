using Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
   public class PreallocationRoomInfo
    {
        public string RoomIndex { get; set; }

        public string RoomState { get; set; }

        public string RoomType { get; set; }

        public string FloorCode { get; set; }

        public List<PreallocationBedInfo> BedGroup { get; set; } = new List<PreallocationBedInfo>();
    }

    public class PreallocationBedInfo
    {
        public string BedCode { get; set; }

        public string BedState { get; set; }

        //public T_NEW_STUDENT_APPLICATION NewStudent { get; set; }

        //public T_STUDENT OldStudent { get; set; }
    }
}
