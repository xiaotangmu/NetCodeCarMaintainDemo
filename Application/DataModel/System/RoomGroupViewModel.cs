using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class RoomGroupViewModel
    {
        public int TotalCount { get; set; }

        public List<RoomInfoViewModel> Items { get; set; } = new List<RoomInfoViewModel>();
    }
}
