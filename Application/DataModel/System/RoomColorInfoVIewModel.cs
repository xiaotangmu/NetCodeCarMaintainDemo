using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class RoomColorInfoViewModel
    {
        public string RoomIndex { get; set; }

        public string RoomTypeColor { get; set; }

        public List<BedInfoViewModel> BedGroup { get; set; } = new List<BedInfoViewModel>();
    }

    public class BedColorInfoViewModel
    {
        public string Bed { get; set; }

        public string BedStateColor { get; set; }
    }
}
