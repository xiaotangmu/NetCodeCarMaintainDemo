using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class RoomInfoViewModel
    {
        public string RoomIndex { get; set; }

        public string RoomState { get; set; }

        public string RoomType { get; set; }

        public string FloorCode { get; set; }

        public bool IsUse { get; set; }

        public List<BedInfoViewModel> BedGroup { get; set; } = new List<BedInfoViewModel>();
    }
}
