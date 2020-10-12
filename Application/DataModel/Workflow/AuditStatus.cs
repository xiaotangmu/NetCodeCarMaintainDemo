using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public enum AuditStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        WAITTING = 0,
        /// <summary>
        /// 已审核
        /// </summary>
        PASS = 1,
        /// <summary>
        /// 未通过审核
        /// </summary>
        REFUSE = 2,
        /// <summary>
        /// 未提交审核
        /// </summary>
        NOT_COMMIT = 3,
        /// <summary>
        /// 流程已結束
        /// </summary>
        END = 99
    }

    public class AuditStatusConverter
    {
        public static string ConvertEnumToDisplay(AuditStatus status)
        {
            string display = string.Empty;
            switch (status)
            {
                case AuditStatus.NOT_COMMIT:
                    display = "未提交";
                    break;
                case AuditStatus.PASS:
                    display = "已審核";
                    break;
                case AuditStatus.REFUSE:
                    display = "未通過審核";
                    break;
                case AuditStatus.WAITTING:
                    display = "待審核";
                    break;
                case AuditStatus.END:
                    display = "流程已結束";
                    break;
                default:
                    break;
            }
            return display;
        }

        public static string ConvertStringToDisplay(string status)
        {
            string display = string.Empty;
            switch (status)
            {
                case "3":
                    display = "未提交";
                    break;
                case "1":
                    display = "已審核";
                    break;
                case "2":
                    display = "未通過審核";
                    break;
                case "0":
                    display = "待審核";
                    break;
                case "99":
                    display = "流程已結束";
                    break;
                default:
                    break;
            }
            return display;
        }
    }
}
