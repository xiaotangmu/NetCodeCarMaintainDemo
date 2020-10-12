using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.System
{
    public enum RoomState
    {
        NOT_VACANT_CLEAN = 0,
        VACANT_CLEAN = 1
    }

    public class RoomStateConverter
    {
        public static async Task<string> ConvertToString(string state)
        {
            string result = string.Empty;
            switch (state)
            {
                case "0":
                    result = await Localization.Localizer.GetValueAsync("not_vacant_clean");
                    break;
                case "1":
                    result = await Localization.Localizer.GetValueAsync("vacant_clean");
                    break;
            }
            return result;
        }
    }
}
